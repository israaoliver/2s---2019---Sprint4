using System.Net.NetworkInformation;
using System.IO;
namespace RoleTopMVC.Models
{
    public class Servicos
    {
        public string Nome {get;set;}

        public double Preco {get;set;}

        public Servicos()
        {

        }

        public Servicos(string nome, double preco)
        {

            this.Nome = nome;
            this.Preco = preco;
        }


    }
}