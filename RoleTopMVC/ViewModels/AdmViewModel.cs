using System.Collections.Generic;
using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class  AdmViewModel : DashboardViewModel 
    {
        public List<Cliente> ListaUsuario {get;set;}
        public uint EventosTotal {get;set;}
        public uint Usuarios {get;set;}
        public uint UsuariosBanidos {get;set;}
        public uint Suportes {get;set;}

        public AdmViewModel()
        {

        }
    }
}