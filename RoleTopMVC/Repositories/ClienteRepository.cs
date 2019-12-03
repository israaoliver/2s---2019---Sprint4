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

        public bool Atualizar(Cliente c, string email)
        {
            var clienteTotais = File.ReadAllLines(PATH);
            var clienteCSV = Preparar(c);
            var linhaCliente = -1;
            var resultado = false;

            for (int i = 0; i < clienteTotais.Length; i++)
            {
                var emailConvertido = ExtrairValorDoCampo("email", clienteTotais[i]);
                if (email.Equals(emailConvertido))
                {
                    linhaCliente = i;
                    resultado = true;
                    break;
                }
            }
            if (resultado)
            {
                clienteTotais[linhaCliente] = clienteCSV;
                File.WriteAllLines(PATH, clienteTotais);
            }
            return resultado;
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
                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario", item));
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
            return $"tipo_usuario={c.TipoUsuario};nome={c.Nome};email={c.Email};senha={c.Senha};telefone={c.Telefone};cpf={c.CPF}";
        }
}
}