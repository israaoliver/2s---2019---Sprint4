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
        private ClienteRepository clienteRepository = new ClienteRepository();

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

        public IActionResult CadastrarEvento(IFormCollection form)
        {
            try
            {
                Evento e = new Evento(
                clienteRepository.ObterInfo(ObterUsuarioSession()),
                form["nomeEvento"],
                form["tipo"],
                form["opcional"],
                form["numero"],
                form["descricao"],
                DateTime.Parse(form["dataDoEvento"])
            );
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new MensagemViewModel("Erro em cadastrar evento"){
                    NomeView = "Usuario",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });

            }

            return View();
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
            
            Suporte msg = new Suporte(clienteRepository.ObterInfo(ObterUsuarioSession()),form["problema"],form["descricao"], DateTime.Now);
            
            suporteRepository.Inserir(msg);
            return View("Sucesso", new MensagemViewModel("Falha em enviar a mensagem"){
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });


        }
    }
}