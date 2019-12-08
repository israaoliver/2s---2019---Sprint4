using System.Data;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class AdmController : AbstractController
    {

        private EventoRepository eventoRepository = new EventoRepository();
        private ClienteRepository clienteRepository = new ClienteRepository();
        private SuporteRepository suporteRepository = new SuporteRepository();

        

        public DashboardViewModel DashboardEvento()
        {
            var eventos = eventoRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach (var evento in eventos)
            {
                switch (evento.Status)
                {
                    case (uint) StatusEvento.APROVADO:
                        dashboardViewModel.EventosAprovados++;
                    break;
                    case (uint) StatusEvento.REPROVADO:
                        dashboardViewModel.EventosReprovados++;
                    break;
                    default:
                        dashboardViewModel.EventosPendentes++;
                    break;

                }
                dashboardViewModel.Eventos.Add(evento);
            }
                dashboardViewModel.Eventos = eventos;
                dashboardViewModel.NomeView ="Adm";
                dashboardViewModel.NomeView2 = "dashboard";
                dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

                return dashboardViewModel;
        }
        public IActionResult Index()
        {

            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
                var totalUsuarios = 0;
                var totalSuporte = 0;
                var totalEventos = 0;
                var totalBanidos = 0;
                foreach (var e in eventoRepository.ObterTodos())
                {
                    totalEventos ++;
                }
                foreach (var e in clienteRepository.ObterTodosClientes())
                {
                    if (e.TipoUsuario == (uint) TipoUsuario.CLIENTE)
                    {
                        totalUsuarios ++;
                    }else
                    {
                        totalBanidos ++;
                    }
                }
                foreach (var s in suporteRepository.ObterTodos())
                {
                    totalSuporte++;
                }
                AdmViewModel avm = new AdmViewModel();
                var dashboard = DashboardEvento(); 
                avm.EventosTotal = (uint) totalEventos ;
                avm.Usuarios = (uint) totalUsuarios;
                avm.UsuariosBanidos = (uint) totalBanidos;
                avm.Suportes = (uint) totalSuporte;
                avm.EventosAprovados = dashboard.EventosAprovados;
                avm.EventosReprovados = dashboard.EventosReprovados;
                avm.EventosPendentes = dashboard.EventosPendentes;
                avm.NomeView = "Adm";
                avm.NomeView2 = "AdmHome";
                avm.UsuarioEmail = ObterUsuarioSession();

                return View(avm);

            }else
            {
                return View("Erro", new MensagemViewModel("Você não possui permissão")
                {
                    NomeView = "Login"
                });
            }
        }
        public IActionResult Historico()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
                
                var dashboard = DashboardEvento(); 
                return View(dashboard);

            }else
            {
                return View("Erro", new MensagemViewModel("Você não possui permissão")
                {
                    NomeView = "Login"
                });
            }

        }

        
        public IActionResult Pendentes()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
            var dashboard = DashboardEvento(); 

            return View(dashboard);        
            }
            else{
                
                return View("Erro", new MensagemViewModel("Você não possui permissão")
                {
                    NomeView = "Login"
                });
            }
        }

        public IActionResult Aprovados()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
            var dashboard = DashboardEvento(); 

            return View(dashboard);        
            }
            else{
                
                return View("Erro", new MensagemViewModel("Você não possui permissão")
                {
                    NomeView = "Login"
                });
            }
        }

        public IActionResult Recusados()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
            var dashboard = DashboardEvento(); 

            return View(dashboard);        
            }
            else{
                
                return View("Erro", new MensagemViewModel("Você não possui permissão")
                {
                    NomeView = "Login"
                });
            }
        }

        // todo : Metodos do Aprovar,Reprovar ou readimitir 

        public IActionResult Aprovar(ulong id)
        {
            var e = eventoRepository.ObterPor(id); 
            e.Status = (uint) StatusEvento.APROVADO;

            if (eventoRepository.Atualizar(e))
            {
                return RedirectToAction ("Pendentes", "Adm");
            }
            else
            {
                return View ("Erro", new MensagemViewModel("Não foi possivel Aprovar esse evento")
                {
                    NomeView = "Adm",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }

        public IActionResult Reprovar(ulong id)
        {
            var e = eventoRepository.ObterPor(id);
            e.Status = (uint) StatusEvento.REPROVADO;

            if (eventoRepository.Atualizar(e))
            {
                return RedirectToAction ("Pendentes", "Adm");
            }
            else
            {
                return View ("Erro", new MensagemViewModel("Não foi possivel Reprovar esse evento")
                {
                    NomeView = "Adm",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }
        public IActionResult Readimitir(ulong id)
        {
            var evento = eventoRepository.ObterPor(id);
            evento.Status = (uint) StatusEvento.PENDENTE;

            if (eventoRepository.Atualizar(evento))
            {
                return RedirectToAction ("Recusados", "Adm");
            }
            else
            {
                return View ("Erro", new MensagemViewModel("Não foi possivel Readimitir esse evento")
                {
                    NomeView = "Adm",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }


        // todo : ==========================    Area de Usuarios =================================================

        public IActionResult Usuario()
        {
            if (!string.IsNullOrEmpty(ObterUsuarioSession()) && (uint)TipoUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
                
                var usuarios = clienteRepository.ObterTodosClientes(); 
                return View();

            }else
            {
                return View("Erro", new MensagemViewModel("Você não possui permissão")
                {
                    NomeView = "Login"
                });
            }
        }
	
    }

}