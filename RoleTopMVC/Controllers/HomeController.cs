using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Controllers;
using RoleTopMVC.Repositories;
using RoleTopMVC.Models;
using RoleTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class HomeController : AbstractController
    {

        private EventoRepository eventoRepository = new EventoRepository();

        public IActionResult Index()
        { 

            var eventos = eventoRepository.ObterTodos();


            return View(new EventoViewModel(){

                Eventos = eventos,
                NomeView = "Home",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }


    }
}
