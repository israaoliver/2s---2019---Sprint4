namespace RoleTopMVC.Models
{
    public class Suporte
    {
        public Cliente Usuario {get;set;}
        public string Problema {get;set;}
        public string Mensagem {get;set;}

        public Suporte(string problema, string mensagem)
        {
            this.Problema = problema;
            this.Mensagem = mensagem;
        }
    }
}