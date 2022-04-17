using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class Cabinet : Controller
    {
        [Route("[controller]/[action]")]
        public IActionResult Main()
        {
            return View();
        }
    }
}
