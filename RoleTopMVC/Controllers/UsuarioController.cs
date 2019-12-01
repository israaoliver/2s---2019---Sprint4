using System.Net.Http;
using System;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using System.Collections.Generic;

namespace RoleTopMVC.Controllers

{
    public class UsuarioController : AbstractController
    {

        private SuporteRepository suporteRepository = new SuporteRepository();
        private EventoRepository eventoRepository = new EventoRepository();
        private ClienteRepository clienteRepository = new ClienteRepository();
        private ServicosRepository servicosRepository = new ServicosRepository();

        public IActionResult Index()
        {
            return View(new MensagemViewModel(){
                NomeView ="User_Home",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }
        
        // todo : Comesso do Cadastro de evento ==================================================================

        public IActionResult EventoCadastro()
        {

            var servicos = servicosRepository.ObterTodos();

            return View(new ServicoViewModel(servicos){
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        public IActionResult CadastrarEvento(IFormCollection form)
        {
            try
            {
                Evento e = new Evento();
                e.Cliente = clienteRepository.ObterInfo(ObterUsuarioSession());
                e.NomeEvento = form["nomeEvento"];
                e.TipoEvento = form["tipo"];
                e.Quantidade = form["numero"];
                e.Descricao = form["descricao"];
                e.DiaDoEvento = DateTime.Parse(form["dataDoEvento"]);
                e.DataRegistro = DateTime.Now;

                var nomeServico = form["servico"];
                Servicos servico = new Servicos(nomeServico, servicosRepository.ObterPrecoDe(nomeServico));
                e.Servicos = servico;

                if (eventoRepository.Inserir(e))
                {
                    return View("Sucesso", new BaseViewModel(){
                        NomeView = "Usuario"
                    });
                }else
                {
                    return View ("Erro", new MensagemViewModel("Falha em Cadastrar seu Evento"){
                        NomeView = "Usuario",
                        UsuarioNome = ObterUsuarioNomeSession(),
                        UsuarioEmail = ObterUsuarioSession()
                    });
                }

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

        }

            // todo: Fim do Cadastro de Evento ==============================================================================
        public IActionResult Eventos()
        {
            
            var eventoCliente = eventoRepository.ObeterEventoPorCliente(ObterUsuarioSession());
            string vazio ;

            if (eventoCliente == null)
            {
                vazio = "" ;
            }else
            {
                vazio = "tem";
            }


            return View(new EventoViewModel()
            {
                Stats = "",
                Vazio = vazio,
                Eventos = eventoCliente,
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession(),
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
            return View("Sucesso", new MensagemViewModel(){
                NomeView ="Usuario",
                NomeView2 = "Suporte",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });


        }
    }
}