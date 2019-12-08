using System;
namespace RoleTopMVC.Models
{
    public class Suporte
    {
        public Cliente Usuario {get;set;}
        public string Problema {get;set;}
        public string Mensagem {get;set;}
        public DateTime DataDoEnvio {get;set;}

        public Suporte()
        {
            this.DataDoEnvio = new DateTime();
        }
        public Suporte(Cliente usuario,string problema, string mensagem,DateTime dataDoEnvio)
        {
            this.Usuario = usuario;
            this.Problema = problema;
            this.Mensagem = mensagem;
            this.DataDoEnvio = dataDoEnvio;
        }
    }
}