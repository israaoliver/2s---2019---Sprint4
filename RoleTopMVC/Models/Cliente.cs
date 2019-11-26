using System.IO;
namespace RoleTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public string Telefone {get;set;}
        public string CPF {get;set;}

        public Cliente()
        {

        }

        public Cliente(string nome, string email,string senha,string telefone, string cpf)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Telefone = telefone;
            this.CPF = cpf;

        }   
    }
}