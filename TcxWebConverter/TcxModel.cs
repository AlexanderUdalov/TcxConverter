using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TcxConverter
{
    [XmlRoot(ElementName = "AverageHeartRateBpm", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class AverageHeartRateBpm
    {
        [XmlElement(ElementName = "Value", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "MaximumHeartRateBpm", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class MaximumHeartRateBpm
    {
        [XmlElement(ElementName = "Value", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "HeartRateBpm", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class HeartRateBpm
    {
        [XmlElement(ElementName = "Value", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "TPX", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
    public class TPX
    {
        [XmlElement(ElementName = "Speed", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
        public string Speed { get; set; }
        [XmlElement(ElementName = "RunCadence", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
        public string RunCadence { get; set; }
    }

    [XmlRoot(ElementName = "Extensions", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Extensions
    {
        [XmlElement(ElementName = "TPX", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
        public TPX TPX { get; set; }
        [XmlElement(ElementName = "LX", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
        public LX LX { get; set; }
    }

    [XmlRoot(ElementName = "Trackpoint", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Trackpoint
    {
        [XmlElement(ElementName = "Time", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Time { get; set; }
        [XmlElement(ElementName = "DistanceMeters", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string DistanceMeters { get; set; }
        [XmlElement(ElementName = "HeartRateBpm", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public HeartRateBpm HeartRateBpm { get; set; }
        [XmlElement(ElementName = "Extensions", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Extensions Extensions { get; set; }
    }

    [XmlRoot(ElementName = "Track", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Track
    {
        [XmlElement(ElementName = "Trackpoint", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public List<Trackpoint> Trackpoint { get; set; }
    }

    [XmlRoot(ElementName = "LX", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
    public class LX
    {
        [XmlElement(ElementName = "AvgSpeed", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
        public string AvgSpeed { get; set; }
        [XmlElement(ElementName = "AvgRunCadence", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
        public string AvgRunCadence { get; set; }
        [XmlElement(ElementName = "MaxRunCadence", Namespace = "http://www.garmin.com/xmlschemas/ActivityExtension/v2")]
        public string MaxRunCadence { get; set; }
    }

    [XmlRoot(ElementName = "Lap", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Lap
    {
        [XmlElement(ElementName = "TotalTimeSeconds", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string TotalTimeSeconds { get; set; }
        [XmlElement(ElementName = "DistanceMeters", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string DistanceMeters { get; set; }
        [XmlElement(ElementName = "MaximumSpeed", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string MaximumSpeed { get; set; }
        [XmlElement(ElementName = "Calories", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Calories { get; set; }
        [XmlElement(ElementName = "AverageHeartRateBpm", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public AverageHeartRateBpm AverageHeartRateBpm { get; set; }
        [XmlElement(ElementName = "MaximumHeartRateBpm", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public MaximumHeartRateBpm MaximumHeartRateBpm { get; set; }
        [XmlElement(ElementName = "Intensity", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Intensity { get; set; }
        [XmlElement(ElementName = "TriggerMethod", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string TriggerMethod { get; set; }
        [XmlElement(ElementName = "Track", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Track Track { get; set; }
        [XmlElement(ElementName = "Extensions", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Extensions Extensions { get; set; }
        [XmlAttribute(AttributeName = "StartTime")]
        public string StartTime { get; set; }
    }

    [XmlRoot(ElementName = "Version", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Version
    {
        [XmlElement(ElementName = "VersionMajor", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string VersionMajor { get; set; }
        [XmlElement(ElementName = "VersionMinor", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string VersionMinor { get; set; }
        [XmlElement(ElementName = "BuildMajor", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string BuildMajor { get; set; }
        [XmlElement(ElementName = "BuildMinor", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string BuildMinor { get; set; }
    }

    [XmlRoot(ElementName = "Creator", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Creator
    {
        [XmlElement(ElementName = "Name", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Name { get; set; }
        [XmlElement(ElementName = "UnitId", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string UnitId { get; set; }
        [XmlElement(ElementName = "ProductID", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string ProductID { get; set; }
        [XmlElement(ElementName = "Version", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Version Version { get; set; }
    }

    [XmlRoot(ElementName = "Activity", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Activity
    {
        [XmlElement(ElementName = "Id", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Id { get; set; }
        [XmlElement(ElementName = "Lap", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public List<Lap> Lap { get; set; }
        [XmlElement(ElementName = "Creator", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Creator Creator { get; set; }
        [XmlAttribute(AttributeName = "Sport")]
        public string Sport { get; set; }
    }

    [XmlRoot(ElementName = "Activities", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Activities
    {
        [XmlElement(ElementName = "Activity", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Activity Activity { get; set; }
    }

    [XmlRoot(ElementName = "Build", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Build
    {
        [XmlElement(ElementName = "Version", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Version Version { get; set; }
    }

    [XmlRoot(ElementName = "Author", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Author
    {
        [XmlElement(ElementName = "Name", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Build", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Build Build { get; set; }
        [XmlElement(ElementName = "LangID", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string LangID { get; set; }
        [XmlElement(ElementName = "PartNumber", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public string PartNumber { get; set; }
    }


    [XmlRoot(ElementName = "TrainingCenterDatabase", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class TrainingCenterDatabase
    {
        [XmlElement(ElementName = "Activities", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Activities Activities { get; set; }
        [XmlElement(ElementName = "Author", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
        public Author Author { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "ns5", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns5 { get; set; }
        [XmlAttribute(AttributeName = "ns3", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns3 { get; set; }
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "ns4", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns4 { get; set; }
    }
}
