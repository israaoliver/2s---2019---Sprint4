using System.Net.Http;
using System;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using System.Collections.Generic;
using RoleTopMVC.Enums;

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
                Servicos s = new Servicos();
                s.Nome = nomeServico;
                s.Preco = servicosRepository.ObterPrecoDe(nomeServico);
                e.Servicos = s;

                if (eventoRepository.Inserir(e))
                {
                    return View("Sucesso", new MensagemViewModel(){
                        NomeView = "Usuario",
                        NomeView2 = "Cadastro",
                        UsuarioEmail = ObterUsuarioSession(),
                        UsuarioNome = ObterUsuarioNomeSession()


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
            uint stats = 0 ;
            var numeroStatus = 0;
            foreach (var e in eventoCliente)
            {
                if (e.Status == 3)
                {
                    stats = e.Status;
                    numeroStatus ++;
                }
            }



            if (eventoCliente == null)
            {
                vazio = "" ;
            }else
            {
                vazio = "tem";
            }


            return View(new EventoViewModel()
            {
                Status = stats,
                NumeroDeStatus = numeroStatus,
                Stats = "",
                Vazio = vazio,
                Eventos = eventoCliente,
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession(),
            });
        }
        // todo: Informações do usuario ============================================

        public IActionResult Informacoes()
        {
            var c = clienteRepository.ObterInfo(ObterUsuarioSession());

            return View(new BaseViewModel(){
                Cliente = c,
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession(),

            });
        }

        public IActionResult InfoAlterar()
        {
            var c = clienteRepository.ObterInfo(ObterUsuarioSession());

            return View(new BaseViewModel(){
                Cliente = c,
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession(),

            });
        }

        public IActionResult AlterarInforamacoUsuario(IFormCollection form)
        {
            var C2 = clienteRepository.ObterInfo(ObterUsuarioSession());
            Cliente c = new Cliente();
            c.TipoUsuario = (uint) TipoUsuario.CLIENTE;
            c.Nome = form["nome"];
            c.Email = form["email"];
            c.Senha = C2.Senha;
            c.Telefone = form["telefone"];
            c.CPF = form["cpf"];
            

            if (clienteRepository.Atualizar(c, ObterUsuarioSession()))
            {
                HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
                HttpContext.Session.Remove(SESSION_CLIENTE_NOME);

                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, c.Email);
                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);


                return View ("Sucesso", new MensagemViewModel("Informações Alteradas"){
                NomeView = "Usuario",
                NomeView2 = "Informacao",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()

            });
            }else
            {
                return View ("Erro", new MensagemViewModel("Falha em alterar informações!"){
                NomeView = "Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()

            });
            }

        }

        public IActionResult InfoSenha()
        {
            return View(new BaseViewModel()
            {
                NomeView="Usuario",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession(),
            });
        }

        public IActionResult AlterarSenha(IFormCollection form)
        {
            var c = clienteRepository.ObterInfo(ObterUsuarioSession());
            string senhaAtual = form["senhaAtual"];
            string senha = form["senha"];
            string repSenha = form["repSenha"];

            if (c.Senha == senhaAtual)
            {
                if (senha == repSenha)
                {
                    c.Senha = senha;
                    clienteRepository.Atualizar(c, ObterUsuarioSession());
                    return View("Sucesso", new  MensagemViewModel("Senha Alterada")
                    {
                        NomeView = "Usuario",
                        NomeView2 = "Informacao",
                        UsuarioEmail = ObterUsuarioSession(),
                        UsuarioNome = ObterUsuarioNomeSession()

                    });
                }
                else
                {
                    return View("Erro", new MensagemViewModel("Senhas diferentes")
                    {
                        NomeView = "Usuario",
                        UsuarioEmail = ObterUsuarioSession(),
                        UsuarioNome = ObterUsuarioNomeSession(),
                    });
                }
            }
            else
            {
                return View("Erro", new MensagemViewModel("Senha atual incorreta")
                {
                    NomeView = "Usuario",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession(),
                });
            }

        }

        // todo: Suporte =====================
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