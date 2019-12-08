using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
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
                Cliente c = new Cliente();

                c.Nome = form["nome"];
                c.Email = form["email"];
                c.Senha = ClienteRepository.ComputeSha256Hash(form["senha"]);
                c.Telefone = form["telefone"];
                c.CPF = form["cpf"];
                c.TipoUsuario = (uint) TipoUsuario.CLIENTE;
                clienteRepository.Inserir(c);
                
                string userEmail = c.Email;
                string userNome = c.Nome;
                string userTipo = c.TipoUsuario.ToString();

                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, userEmail);
                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, userNome);
                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, userTipo);

                return View("Sucesso", new PagamentoViewModel(){
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new MensagemViewModel("Erro em cadastrar usuario"){
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }
    }
}