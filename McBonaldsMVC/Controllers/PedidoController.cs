using System;
using System.Collections.Generic;
using McBonaldsMVC.Enums;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace McBonaldsMVC.Controllers
{
    public class PedidoController : AbstractController
    {

        ClienteRepository clienteRepository = new ClienteRepository();
        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();

        ShakesRepository shakesRepository = new ShakesRepository();

        public IActionResult Index()
        {
            

            PedidoViewModel pvm = new PedidoViewModel();
            pvm.Hamburgueres = hamburguerRepository.ObterTodos();
            pvm.Shakes = shakesRepository.ObterTodos();

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pvm.NomeCliente = nomeUsuarioLogado;
            }
            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null)
            {
                pvm.Cliente = clienteLogado;
            }


            pvm.NomeView = "Pedido";
            pvm.UsuarioEmail = usuarioLogado;
            pvm.UsuarioNome = nomeUsuarioLogado;
            

            return View(pvm);
        }

        public IActionResult Registrar(IFormCollection form)
        {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido();

            var nomeShake = form["shake"];
            Shake shake = new Shake();
            shake.Nome = nomeShake;
            shake.Preco = shakesRepository.ObterPrecoDe(nomeShake);

            pedido.Shake = shake;

            var nomeHamburguer = form["hamburguer"];
            Hamburguer hamburguer = new Hamburguer(nomeHamburguer, hamburguerRepository.ObterPrecoDe(nomeHamburguer));

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente(){
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            
            };

            pedido.Cliente = cliente;
            
            pedido.DataDoPedido = DateTime.Now;
            
            pedido.PrecoTotal = shake.Preco + hamburguer.Preco;

            if(pedidoRepository.Inserir(pedido))
            {
            return View("Sucesso",new RespostaViewModel(){
                NomeView = "Pedido"
                });
                
            }else{

                return View("Erro", new RespostaViewModel(){
                    NomeView = "Pedido"
                });
            }
            
        }

        public IActionResult Aprovar(ulong id)
        {
            var pedido = pedidoRepository.ObterPor(id);  
            pedido.Status = (uint) StatusPedido.APROVADO;

            if(pedidoRepository.Atualizar(pedido))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else
            {
                return View("Erro", new RespostaViewModel("Não foi possivel aprovar este pedido"){
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
        public IActionResult Reprovar(ulong id)
        {
            var pedido = pedidoRepository.ObterPor(id);  
            pedido.Status = (uint) StatusPedido.REPROVADO;

            if(pedidoRepository.Atualizar(pedido))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else
            {
                return View("Erro", new RespostaViewModel("Não foi possivel reprovar este pedido"){
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
    }
}
}