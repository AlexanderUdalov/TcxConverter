using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TcxConverter;

namespace TcxWebConverter.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile TcxFile { get; set; }
        [BindProperty]
        public decimal? Distance { get; set; }

        public IActionResult OnPost()
        {
            if (TcxFile == null || Distance == null)
                return new BadRequestResult();

            var stream = TcxFile.OpenReadStream();

            var xmlString = RemoveUnsupportedTypes(stream);

            TrainingCenterDatabase db = null;
            db = Deserialize(xmlString);


            var trackpoints = new List<Trackpoint>();

            foreach (var lap in db.Activities.Activity.Lap)
                trackpoints.AddRange(lap.Track.Trackpoint);

            var baseDistance = decimal.Parse(trackpoints[trackpoints.Count - 1].DistanceMeters, System.Globalization.NumberStyles.AllowDecimalPoint);
            var coef = Distance.Value / baseDistance;

            foreach (var point in trackpoints)
            {
                point.DistanceMeters = (decimal.Parse(point.DistanceMeters, System.Globalization.NumberStyles.AllowDecimalPoint) * coef).ToString();
                point.Extensions.TPX.Speed = (decimal.Parse(point.Extensions.TPX.Speed, System.Globalization.NumberStyles.AllowDecimalPoint) * coef).ToString();
            }

            var newLaps = new List<Lap>();
            int thousandIndex = 1;

            do
            {
                var lapPoints = trackpoints.TakeWhile(x => decimal.Parse(x.DistanceMeters, System.Globalization.NumberStyles.AllowDecimalPoint) < thousandIndex * 1000).ToList();
                var lap = ConfigureLap(db, lapPoints, false);
                newLaps.Add(lap);
                thousandIndex++;

                trackpoints = trackpoints.Skip(lapPoints.Count).ToList();
            }
            while (thousandIndex <= (int)(Distance.Value / 1000));

            var lastPoints = trackpoints;
            var lastLap = ConfigureLap(db, lastPoints, true);
            newLaps.Add(lastLap);

            db.Activities.Activity.Lap = newLaps;

            db.Xsi = null;
            

            XmlSerializer serializer = new XmlSerializer(typeof(TrainingCenterDatabase));
            var resultStream = new MemoryStream();
            serializer.Serialize(resultStream, db);
            resultStream.Position = 0;
            var resultXmlString = ReturnUnsupportedTypes(resultStream);

            byte[] bytes = Encoding.Default.GetBytes(resultXmlString);
            string file_type = "application/octet-stream";
            string file_name = TcxFile.FileName.Insert(TcxFile.FileName.IndexOf(".tcx"), "_converted");
            return File(bytes, file_type, file_name);
        }

        private static Lap ConfigureLap(TrainingCenterDatabase db, List<Trackpoint> lapPoints, bool isLast)
        {
            var Track = new Track
            {
                Trackpoint = lapPoints
            };
            var DistanceMeters = isLast ? (decimal.Parse(lapPoints[lapPoints.Count - 1].DistanceMeters, System.Globalization.NumberStyles.AllowDecimalPoint) % 1000).ToString() : "1000";
            var StartTime = lapPoints[0].Time;
            var MaximumSpeed = lapPoints.Max(x => decimal.Parse(x.Extensions.TPX.Speed, System.Globalization.NumberStyles.AllowDecimalPoint)).ToString();
            var MaximumHeartRateBpm = new MaximumHeartRateBpm
            {
                Value = lapPoints.Max(x => decimal.Parse(x.HeartRateBpm.Value, System.Globalization.NumberStyles.AllowDecimalPoint)).ToString()
            };
            var AverageHeartRateBpm = new AverageHeartRateBpm
            {
                Value = lapPoints.Average(x => decimal.Parse(x.HeartRateBpm.Value, System.Globalization.NumberStyles.AllowDecimalPoint)).ToString()
            };
            var TriggerMethod = "Manual";
            var Intensity = db.Activities.Activity.Lap[0].Intensity;
            var Calories = db.Activities.Activity.Lap.Average(x => decimal.Parse(x.Calories, System.Globalization.NumberStyles.AllowDecimalPoint)).ToString();
            var Extensions = new Extensions
            {
                LX = new LX
                {
                    AvgRunCadence = lapPoints.Average(x => decimal.Parse(x.Extensions.TPX.RunCadence, System.Globalization.NumberStyles.AllowDecimalPoint)).ToString(),
                    AvgSpeed = lapPoints.Average(x => decimal.Parse(x.Extensions.TPX.Speed, System.Globalization.NumberStyles.AllowDecimalPoint)).ToString(),
                    MaxRunCadence = lapPoints.Max(x => decimal.Parse(x.Extensions.TPX.RunCadence, System.Globalization.NumberStyles.AllowDecimalPoint)).ToString()
                }
            };
            var TotalTimeSeconds = (DateTime.Parse(lapPoints[lapPoints.Count - 1].Time) -
                            DateTime.Parse(lapPoints[0].Time)).TotalSeconds.ToString();

            return new Lap
            {
                Track = Track,
                DistanceMeters = DistanceMeters,
                StartTime = StartTime,
                MaximumSpeed = MaximumSpeed,
                MaximumHeartRateBpm = MaximumHeartRateBpm,
                AverageHeartRateBpm = AverageHeartRateBpm,
                TriggerMethod = TriggerMethod,
                Intensity = Intensity,
                Calories = Calories,
                Extensions = Extensions,
                TotalTimeSeconds = TotalTimeSeconds
            };
        }

        private static TrainingCenterDatabase Deserialize(string s)
        {
            TrainingCenterDatabase db;
            XmlSerializer serializer = new XmlSerializer(typeof(TrainingCenterDatabase));
            db = (TrainingCenterDatabase)serializer.Deserialize(new StringReader(s));
            return db;
        }

        private static string RemoveUnsupportedTypes(Stream stream)
        {
            var resultStream = new MemoryStream();
            var lines = new List<string>();
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Creator xsi:type=\"Device_t\""))
                        line = line.Remove(line.IndexOf(" xsi")) + ">";

                    if (line.Contains("Author xsi:type=\"Application_t\""))
                        line = line.Remove(line.IndexOf(" xsi")) + ">";
                    lines.Add(line);
                }
            }
            return string.Join("", lines.ToArray());
        }

        private static string ReturnUnsupportedTypes(Stream stream)
        {
            var resultStream = new MemoryStream();
            var lines = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("<Creator>"))
                        line = line.Insert(line.IndexOf(">"), " xsi:type=\"Device_t\"");

                    if (line.Contains("<Author>"))
                        line = line.Insert(line.IndexOf(">"), " xsi:type=\"Application_t\"");
                    lines.Add(line);
                }
            }
            return string.Join("", lines.ToArray());
        }
    }
}
