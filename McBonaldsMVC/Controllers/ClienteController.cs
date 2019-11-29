using System;
using McBonaldsMVC.Enums;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class ClienteController : AbstractController
    {

        private ClienteRepository clienteRepository = new ClienteRepository();
        private PedidoRepository pedidoRepository = new PedidoRepository();

        [HttpGet]
        public IActionResult Login()
        {
            return View(new BaseViewModel(){

                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try
            {
                System.Console.WriteLine("====================================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("====================================");

                var usuario = form["email"];
                var senha = form["senha"];

                var c = clienteRepository.ObterPor(usuario); 

                if(c != null)
                {
                    if(c.Senha.Equals(senha))
                    {
                        switch (c.TipoUsuario)
                        {
                            case (uint) TipoUsuario.CLIENTE:

                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, c.TipoUsuario.ToString());
                                return RedirectToAction("Historico", "Cliente");
                            
                            case (uint) TipoUsuario.ADMINISTRADOR:
                                
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, c.TipoUsuario.ToString());
                                return RedirectToAction("Dashboard", "Administrador");
                            
                            default:

                                return View("Erro", new RespostaViewModel("Erro de TIPO no codigo"));
                            
                        }

                    }
                    else
                    {
                        return View("Erro" , new RespostaViewModel("Senha incorreta"));
                    }

                }
                else
                {
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não encontrado."));
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }

        }

        public IActionResult Historico ()
        {
            var emailCliente = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            var pedidosCliente = pedidoRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel(){

                Pedidos = pedidosCliente,
                NomeView = "Historico",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession() 

            });
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