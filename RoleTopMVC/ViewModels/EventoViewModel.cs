using System.Collections.Generic;
using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class EventoViewModel : BaseViewModel
    {
        public List<Evento> Eventos {get;set;}
        public string Vazio  {get;set;}
        public string Stats {get;set;}
        public uint NumeroDeApagados {get;set;}
        public uint NumeroDeEventos {get;set;}

    }
}