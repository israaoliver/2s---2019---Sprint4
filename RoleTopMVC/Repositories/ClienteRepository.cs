using System.Net;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";

        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Cliente c)
        {
            var l = new string[] { Preparar(c)};
            File.AppendAllLines(PATH, l);

            return true;
        }

        public Cliente ObterInfo(string email)
        {
            var linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                if(ExtrairValorDoCampo("email", item).Equals(email))
                {
                    
                    Cliente c = new Cliente();      
                    c.Nome = ExtrairValorDoCampo("nome", item);
                    c.Email = ExtrairValorDoCampo("email", item);
                    c.Senha = ExtrairValorDoCampo("senha", item);
                    c.Telefone = ExtrairValorDoCampo("telefone", item);
                    c.CPF = ExtrairValorDoCampo("cpf", item);
                    return c;
                }                
            }
            return null;
    }

        private string Preparar(Cliente c)
        {
            return $"nome={c.Nome};email={c.Email};senha={c.Senha};telefone={c.Telefone};cpf={c.CPF}";
        }
}
}