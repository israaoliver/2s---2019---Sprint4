using System.Collections.Generic;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class ServicosRepository
    {
        private const string PATH = "Database/Servicos.csv";

        public double ObterPrecoDe(string nomeServico)
        {
            var lista = ObterTodos();
            var preco = 0.0;

            foreach (var item in lista)
            {
                if(item.Nome.Equals(nomeServico))
                {
                    preco = item.Preco;
                    break;
                }
            }
            return preco;
        }

        public List<Servicos> ObterTodos()
        {
            List<Servicos> servicos = new List<Servicos>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var l in linhas)
            {
                Servicos s = new Servicos();
                string[] dados = l.Split(";");
                s.Nome = dados[0];
                s.Preco = double.Parse(dados[1]);
                servicos.Add(s);
            }

            return servicos;
        }
    }
}