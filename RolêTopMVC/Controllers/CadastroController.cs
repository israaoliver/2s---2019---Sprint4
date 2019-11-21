using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.Repositories;

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

            ViewData["Action"] = "Cadastro";
            ViewData["NomeView"] = "Cadastro";
            try
            {
                Cliente c = new Cliente(form["nome"],form["email"],form["telefone"],form["senha"],form["cpf"]);

                clienteRepository.Inserir(c);
                return View("Cad_Sucesso");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Cad_Erro");
            }
            
        }
    }
}