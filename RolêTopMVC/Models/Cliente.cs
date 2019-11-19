using System.IO;
namespace RolêTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Telefone {get;set;}
        public string Senha {get;set;}
        public string CPF {get;set;}

        public Cliente(string nome, string email, string telefone, string senha, string cpf)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Senha = senha;
            this.CPF = cpf;

        }   
    }
}