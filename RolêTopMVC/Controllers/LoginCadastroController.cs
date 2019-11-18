using Microsoft.AspNetCore.Mvc;

namespace RolêTopMVC.Controllers
{
    public class LoginCadastroController : Controller
    {
        public IActionResult Index()
        {
            ViewData["NomeView"] = "LoginCadastro";
            return View();
        }
        
    }
}