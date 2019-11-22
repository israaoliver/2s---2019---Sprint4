using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RolêTopMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            ViewData["NomeView"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            try
            {
                System.Console.WriteLine("====================================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("====================================");

                var user = form["email"];
                var senha = form["senha"];

                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
                
            }
        }
        public IActionResult Index()
        {
            ViewData["NomeView"] = "User_Home";
            return View();
        }
    }
}