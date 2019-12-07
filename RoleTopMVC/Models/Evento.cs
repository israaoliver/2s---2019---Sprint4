using System;
namespace RoleTopMVC.Models
{
    public class Evento
    {
        public ulong Id {get;set;}
        public Cliente Cliente {get;set;}
        public string NomeEvento {get;set;}
        public string TipoEvento {get;set;}
        public Servicos Servicos {get;set;}
        public string Quantidade {get;set;}
        public string Descricao{get;set;}
        public DateTime DiaDoEvento{get;set;}
        public DateTime DataRegistro{get;set;}
        public uint Status {get;set;}
        public bool Pago{get;set;}

        public Evento()
        {
            this.Servicos = new Servicos();
            this.Cliente =  new Cliente();
            this.Id = 0;
            this.Status = 0;
        }
    }
}