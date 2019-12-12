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
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.CLIENTE == uint.Parse(ObterUsuarioTipoSession()))
            {
                return View(new MensagemViewModel(){
                    NomeView ="User_Home",
                    UsuarioNome = ObterUsuarioNomeSession(),
                    UsuarioEmail = ObterUsuarioSession()
                });
            }else{
                return View("Erro", new MensagemViewModel("Sua Conecção acabou.")
                {
                    NomeView = "Login"
                });
            }
        }
        
        // todo : Comesso do Cadastro de evento ==================================================================

        public IActionResult EventoCadastro()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.CLIENTE == uint.Parse(ObterUsuarioTipoSession()))
            {
                var servicos = servicosRepository.ObterTodos();

                return View(new ServicoViewModel(servicos){
                    NomeView ="Usuario",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });  
            } else{
                return View("Erro", new MensagemViewModel("Sua Conecção acabou.")
                {
                    NomeView = "Login"
                });
                
            }

        }

        public IActionResult CadastrarEvento(IFormCollection form)
        {
            try
            {
                Evento e = new Evento();
                e.Cliente = clienteRepository.ObterCliente(ObterUsuarioSession());
                e.NomeEvento = form["nomeEvento"];
                e.TipoEvento = form["tipo"];
                e.Quantidade = form["numero"];
                e.Descricao = form["descricao"];
                e.DiaDoEvento = DateTime.Parse(form["dataDoEvento"]);
                e.DataRegistro = DateTime.Now;
                e.Pago = false;

                var nomeServico = form["servico"];
                Servicos s = new Servicos();
                s.Nome = nomeServico;
                s.Preco = servicosRepository.ObterPrecoDe(nomeServico);
                e.Servicos = s;

                if (eventoRepository.Inserir(e))
                {
                    return View("Sucesso", new PagamentoViewModel(){

                        Evento = e,
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
        public IActionResult Pagamento(ulong id)
        {
            var e = eventoRepository.ObterPor(id);
            return View(new PagamentoViewModel(){
                Evento = e,
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

            // todo: Fim do Cadastro de Evento ==============================================================================
        public IActionResult Eventos()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.CLIENTE == uint.Parse(ObterUsuarioTipoSession()))
            {
                var eventoCliente = eventoRepository.ObeterEventoPorCliente(ObterUsuarioSession());
                string vazio ;
                uint numeroApagado = 0;
                uint numeroEventos = 0;


                if(!(eventoCliente == null))
                {

                    foreach (var e in eventoCliente){
                        if (e.Status == 3){
                            numeroApagado ++;
                        }
                        numeroEventos ++;
                    }
                }
                if (eventoCliente == null){
                    vazio = "" ;
                }else{
                    vazio = "§";
                }
                return View(new EventoViewModel(){ NumeroDeApagados = numeroApagado,NumeroDeEventos = numeroEventos,Vazio = vazio, Eventos = eventoCliente, NomeView ="Usuario", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession()});
                
            } else{
                return View("Erro", new MensagemViewModel("Sua Conecção acabou.")
                {
                    NomeView = "Login"
                });
            }
            
        }
        // todo: Informações do usuario ============================================

        public IActionResult Informacoes()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.CLIENTE == uint.Parse(ObterUsuarioTipoSession())){

                var c = clienteRepository.ObterCliente(ObterUsuarioSession());
                return View(new BaseViewModel(){
                    Cliente = c,
                    NomeView ="Usuario",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()});
            }
            else{
                return View("Erro", new MensagemViewModel("Sua Conecção acabou.")
                {
                    NomeView = "Login"
                });
            }
        }

        public IActionResult InfoAlterar()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.CLIENTE == uint.Parse(ObterUsuarioTipoSession())){
                
            var c = clienteRepository.ObterCliente(ObterUsuarioSession());
            return View(new BaseViewModel(){
                Cliente = c,
                NomeView ="Usuario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()});
            }else{
                return View("Erro", new MensagemViewModel("Sua Conecção acabou.")
                {
                    NomeView = "Login"
                });
            }
        }

        public IActionResult AlterarInformacaoUsuario(IFormCollection form)
        {
            var C2 = clienteRepository.ObterCliente(ObterUsuarioSession());
            Cliente c = new Cliente();
            c.TipoUsuario = (uint) TipoUsuario.CLIENTE;
            c.Nome = form["nome"];
            c.Email = form["email"];
            c.Senha = C2.Senha;
            c.Telefone = form["telefone"];
            c.CPF = form["cpf"];

                
                    // todo : metodo de atualizar email dos clientes nos eventos dele, so vai ser ativado caso o usuario mude o email
                    if(!(c.Email == ObterUsuarioSession()))
                    {
                        //todo : verifica se o email ja existe no database
                        if (!(clienteRepository.VerificarEmail(c.Email)))
                        {
                            var eventoDesseMano = eventoRepository.ObeterEventoPorCliente(ObterUsuarioSession());
                            
                            if (!(eventoDesseMano == null))
                            {
                                
                                foreach (var e in eventoDesseMano)
                                {
                                    e.Cliente.Email = c.Email;

                                    eventoRepository.Atualizar(e);

                                }
                            }
                        }
                        else
                        {
                            return View ("Erro", new MensagemViewModel($"O email {c.Email} ja existe"){
                            NomeView = "Usuario",
                            UsuarioEmail = ObterUsuarioSession(),
                            UsuarioNome = ObterUsuarioNomeSession()
                            });
                        }

                    }

                    if (clienteRepository.Atualizar(c, ObterUsuarioSession()))
                    {
                        HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
                        HttpContext.Session.Remove(SESSION_CLIENTE_NOME);

                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, c.Email);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);


                        return View ("Sucesso", new PagamentoViewModel("Informações Alteradas"){
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
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.CLIENTE == uint.Parse(ObterUsuarioTipoSession())){
                return View(new BaseViewModel()
                {
                    NomeView="Usuario",
                    UsuarioNome = ObterUsuarioNomeSession(),
                    UsuarioEmail = ObterUsuarioSession()});
            }else{
                return View("Erro", new PagamentoViewModel("Sua Conecção acabou.")
                {
                    NomeView = "Login"
                });
            }
        }

        public IActionResult AlterarSenha(IFormCollection form)
        {
            var c = clienteRepository.ObterCliente(ObterUsuarioSession());
            string senhaAtual = ClienteRepository.ComputeSha256Hash(form["senhaAtual"]);
            string senha = ClienteRepository.ComputeSha256Hash(form["senha"]);
            string repSenha = ClienteRepository.ComputeSha256Hash(form["repSenha"]);

            if (c.Senha == senhaAtual)
            {
                if (senha == repSenha)
                {
                    c.Senha = senha;
                    clienteRepository.Atualizar(c, ObterUsuarioSession());
                    return View("Sucesso", new  PagamentoViewModel("Senha Alterada")
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
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.CLIENTE == uint.Parse(ObterUsuarioTipoSession())){
                return View(new MensagemViewModel(){
                    NomeView ="Usuario",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }else{
                return View("Erro", new MensagemViewModel("Sua Conecção acabou.")
                {
                    NomeView = "Login"
                });
            }
        }
        

        public IActionResult SuporteMensagem(IFormCollection form)
        {
            
            try
            {
                Suporte msg = new Suporte(clienteRepository.ObterCliente(ObterUsuarioSession()),form["problema"],form["descricao"], DateTime.Now);
                suporteRepository.Inserir(msg);
                return View("Sucesso", new PagamentoViewModel(){
                    NomeView ="Usuario",
                    NomeView2 = "Suporte",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
                
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View ("Erro", new MensagemViewModel("Falha em Enviar Mensagem"){
                NomeView = "Usuario",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
                });
            }


        }
    }
}