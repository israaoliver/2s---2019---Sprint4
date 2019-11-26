using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;

namespace RolêTopMVC.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            ViewData["NomeView"] = "Cadastro";
            return View();
        }
        
        public IActionResult CadastrarCliente(IFormCollection form)
        {
            
            ViewData["NomeView"] = "Cadastro";
            try
            {
                Cliente c = new Cliente(form["nome"],form["email"],form["telefone"],form["senha"],form["cpf"]);

                clienteRepository.Inserir(c);

                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, c.Email);
                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);

                return View("Sucesso");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
            
        }
    }
}