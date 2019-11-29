using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Repositories;

namespace RoleTopMVC.Controllers
{
    public class AdmController : AbstractController
    {

        EventoRepository eventoRepository = new EventoRepository();
        public IActionResult Dashboard()
        {
            var eventos = eventoRepository.ObterTodos();
           // DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach (var evento in eventos)
            {
                switch (evento.Status)
                {
                    case (uint) StatusEvento.APROVADO:
                        dashboardViewModel.PedidosAprovados++;
                    break;
                    case (uint) StatusEvento.REPROVADO:
                        dashboardViewModel.PedidosReprovados++;
                    break;
                    default:
                        dashboardViewModel.PedidosPendentes++;
                        dashboardViewModel.Pedidos.Add(evento);
                    break;

                }
            }

            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();
            return View(dashboardViewModel);
        }
    }
}