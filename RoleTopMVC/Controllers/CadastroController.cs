using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            return View(new MensagemViewModel()
            {
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
        
        public IActionResult CadastrarCliente(IFormCollection form)
        {
            

            try
            {
                Cliente c = new Cliente(form["nome"],form["email"],form["senha"],form["telefone"],form["cpf"]);

                clienteRepository.Inserir(c);

                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, c.Email);
                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);

                return View("Sucesso", new MensagemViewModel(){
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new MensagemViewModel(){
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }
    }
}