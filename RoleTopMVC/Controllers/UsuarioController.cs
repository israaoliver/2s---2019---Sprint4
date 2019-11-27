using System.Net.Http;
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
            return View(new MensagemViewModel(){
                NomeView ="User_Home",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }
        public IActionResult EventoCadastro()
        {
            return View(new MensagemViewModel(){
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }


        public IActionResult Eventos()
        {
            return View(new MensagemViewModel(){
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        public IActionResult Suporte()
        {
            return View(new MensagemViewModel(){
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
        

        public IActionResult SuporteMensagem(IFormCollection form)
        {
            HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);

            Suporte msg = new Suporte(form["problema"],form["descricao"]);
            
            suporteRepository.Inserir(msg);
            return View("Sucesso", new MensagemViewModel(){
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });


        }
    }
}