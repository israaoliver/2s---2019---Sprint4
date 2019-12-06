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

        EventoRepository eventoRepository = new EventoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        

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
                        dashboardViewModel.Eventos.Add(evento);
                    break;

                }
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