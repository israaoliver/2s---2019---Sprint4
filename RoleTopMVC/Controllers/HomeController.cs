using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Controllers;
using RoleTopMVC.Models;
using RoleTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class HomeController : AbstractController
    {
        public IActionResult Index()
        {

            return View(new MensagemViewModel(){
                NomeView = "Home",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }


    }
}
