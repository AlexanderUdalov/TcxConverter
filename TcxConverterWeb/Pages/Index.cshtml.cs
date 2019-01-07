using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TcxConverterWeb.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile TcxFile { get; set; }
        [BindProperty]
        public float Distance { get; set; }

        public void OnPost()
        {
            
        }
    }
}
