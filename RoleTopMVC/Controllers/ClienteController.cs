using System;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        private EventoRepository eventoRepository = new EventoRepository();        
        private ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
        public IActionResult Login()
        {
            return View(new MensagemViewModel(){

                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
                });
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

                var c = clienteRepository.ObterInfo(user);
                if (c != null)
                {
                    if (c.Senha.Equals(senha))
                    {
                        switch (c.TipoUsuario)
                        {
                            case (uint) TipoUsuario.CLIENTE:

                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, user);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, c.TipoUsuario.ToString());
                                return RedirectToAction("Index", "Usuario"); 
                            
                            case (uint) TipoUsuario.ADMINISTRADOR:

                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, user);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, c.TipoUsuario.ToString());
                                return RedirectToAction("Index", "Adm");
                            
                            default :

                                return View("Erro", new MensagemViewModel("Erro de TIPO no codigo"){

                                    NomeView = "Login"
                                });


                        }
                    }
                    else
                    {
                        return View("Erro", new MensagemViewModel("Senha Incorreta!"){
                        
                        NomeView = "Login",

                });
                    }
                }
                else
                {
                    return View("Erro", new MensagemViewModel($"Usuario {user} não encontrado."){
                    
                    NomeView = "Login",

                });
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new MensagemViewModel("Falha em Logar!"){
                    NomeView = "Login",

                });
                
            }
        }

        public IActionResult Remover(ulong id)
        {
            var e = eventoRepository.ObterPor(id); 
            e.Status = (uint) StatusEvento.APAGADO;

            if (eventoRepository.Atualizar(e))
            {
                return RedirectToAction ("Eventos", "Usuario");
            }
            else
            {
                return View ("Erro", new MensagemViewModel("Não foi possivel Remover esse evento")
                {
                    NomeView = "Usuario",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}