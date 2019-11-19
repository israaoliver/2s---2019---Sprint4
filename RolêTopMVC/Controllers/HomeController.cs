using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["NomeView"] = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
