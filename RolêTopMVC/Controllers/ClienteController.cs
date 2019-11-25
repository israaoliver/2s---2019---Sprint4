using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

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
        public IActionResult EventoCadastro()
        {
            ViewData["NomeView"] = "Usuario";
            return View();
        }


        public IActionResult Eventos()
        {
            ViewData["NomeView"] = "Usuario";
            return View();
        }

        public IActionResult Suporte()
        {
            ViewData["NomeView"] = "Usuario";
            return View();
        }

        public IActionResult SuporteMensagem(IFormCollection form)
        {
            ViewData["NomeView"] = "Usuario";
            ViewData["NomeView"] = "Suporte";

            Suporte msg = new Suporte(form["problema"],form["descricao"]);

            return View("Sucesso");


        }




    }
}