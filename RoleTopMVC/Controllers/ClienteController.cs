using System;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        
        private ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["NomeView"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {

            ViewData["NomeView"] = "Login";
            try
            {
                System.Console.WriteLine("====================================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("====================================");

                var user = form["email"];
                var senha = form["senha"];

                var c = clienteRepository.ObterInfo(user);
                if (c != null)
                {
                    if (!c.Senha.Equals(senha))
                    {
                        return View("Erro", new MensagemViewModel("Senha Incorreta!"));

                        
                    }
                    else
                    {
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, user);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);
                        
                        return RedirectToAction("Index", "Usuario");

                    }
                }
                else
                {
                    return View("Erro", new MensagemViewModel($"Usuario {user} não encontrado."));
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
                
            }
        }
    }
}