using ESEIM.Models;
using FTU.Utils.HelperNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using thuchanhcurd.Models;

using Microsoft.AspNetCore.Http;
using ESEIM.Utils;

namespace thuchanhcurd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EIMDBContext _context;

        public HomeController(EIMDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
       
    }
}
