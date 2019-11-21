using System;
namespace RolêTopMVC.Models
{
    public class Evento
    {
        public string Nome {get;set;}
        public string TipoEvento {get;set;}
        public string Servicos {get;set;}
        public string Quantidade {get;set;}
        public string Descrição{get;set;}
        public string PublicoPrivado{get;set;}
        public DateTime DiaDoEvento{get;set;}
    }
}