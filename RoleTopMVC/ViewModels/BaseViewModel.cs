using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class BaseViewModel
    {
        public Cliente Cliente {get;set;}
        public string NomeView {get;set;}
        public string NomeView2 {get;set;}
        public string UsuarioNome {get;set;}
        public string UsuarioEmail {get;set;}
        public string UsuarioTipo {get;set;}

        public BaseViewModel()
        {
            this.Cliente = new Cliente();
        }
    }
}