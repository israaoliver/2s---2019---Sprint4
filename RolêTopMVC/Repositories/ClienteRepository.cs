using System.Net;
using System.IO;
using RolêTopMVC.Models;

namespace RolêTopMVC.Repositories
{
    public class ClienteRepository
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

        public string Preparar(Cliente c)
        {
            return $"nome={c.Nome};email={c.Email};telefone={c.Telefone};senha={c.Senha};cpf={c.CPF}";
        }
    }
}