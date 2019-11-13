using Microsoft.AspNetCore.Mvc;

namespace RolêTopMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
    }
}