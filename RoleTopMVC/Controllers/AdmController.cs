using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class AdmController : AbstractController
    {

        EventoRepository eventoRepository = new EventoRepository();

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


                dashboardViewModel.NomeView ="Adm";
                dashboardViewModel.NomeView2 = "dashboard";
                dashboardViewModel.UsuarioNome = ObterUsuarioNomeSession();
                dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

                return dashboardViewModel;
        }
        public IActionResult Index()
        {
            var dashboard = DashboardEvento(); 

            return View(dashboard);
        }

        
        public IActionResult Pendentes()
        {
            var dashboard = DashboardEvento(); 

            return View(dashboard);        
        }

        public IActionResult Aprovados()
        {
            var dashboard = DashboardEvento();
            return View(dashboard);
        }

        public IActionResult Recusados()
        {
            var dashboard = DashboardEvento();
            return View(dashboard);
        }
	
    }

}