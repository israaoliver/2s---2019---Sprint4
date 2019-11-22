using System;
namespace RolêTopMVC.Models
{
    public class Evento
    {
        public string Nome {get;set;}
        public string TipoEvento {get;set;}
        public string Servicos {get;set;}
        public string Quantidade {get;set;}
        public string Descricao{get;set;}
        public string PublicoPrivado{get;set;}
        public DateTime DiaDoEvento{get;set;}

        public Evento(string nome, string tipoEvento, string servicos, string quantidade, string descricao, string publicoPrivado, DateTime diaDoEvento)
        {
            this.Nome = nome;
            this.Servicos = servicos;
            this.Quantidade = quantidade;
            this.Descricao = descricao;
            this.PublicoPrivado = publicoPrivado;
            this.DiaDoEvento = diaDoEvento;
        }
    }
}