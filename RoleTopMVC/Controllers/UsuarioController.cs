using System;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;

namespace RoleTopMVC.Controllers

{
    public class UsuarioController : AbstractController
    {

        private SuporteRepository  suporteRepository = new SuporteRepository();

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
            
            suporteRepository.Inserir(msg);
            return View("Sucesso");


        }
    }
}