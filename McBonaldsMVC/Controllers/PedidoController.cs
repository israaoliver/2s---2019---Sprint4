using System;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace McBonaldsMVC.Controllers
{
    public class PedidoController : Controller
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();

        ShakesRepository shakesRepository = new ShakesRepository();

        public IActionResult Index()
        {
            

            PedidoViewModel pvm = new PedidoViewModel(Shakes = shakesRepository.ObterTodos(););
            pvm.Hamburgueres = hamburguerRepository.ObterTodos();

            PedidoViewModel pmv2 = new PedidoViewModel();
 
            return View(pvm , );
        }

        public IActionResult Registrar(IFormCollection form)
        {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido();

            Shake shake = new Shake();
            shake.Nome = form["shake"];
            shake.Preco = 0.0;

            pedido.Shake = shake;

            Hamburguer hamburguer = new Hamburguer(form["hamburguer"], 0.0);

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente(){
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            
            };

            pedido.Cliente = cliente;
            
            pedido.DataDoPedido = DateTime.Now;
            
            pedido.PrecoTotal = 0.0;

            if(pedidoRepository.Inserir(pedido))
            {
            return View("Sucesso");
                
            }else{

                return View("Erro");
            }
            

            
        }
    }
}