using System.Collections.Generic;
using System.Net;
using System.IO;
using RoleTopMVC.Models;
using System.Security.Cryptography;
using System.Text;

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

        public bool VerificarEmail(string email)
        {
            var clientes = ObterTodosClientes();

            bool emailExiste = false ;

            foreach (var c in clientes)
            {
                if (c.Email == email)
                {
                    emailExiste = true;
                    break;
                }
            }

            if (!(emailExiste))
            {
                emailExiste = false;
            }
            return emailExiste;

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

        public static string ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }
        public Cliente ObterCliente(string email)
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

        public List<Cliente> ObterTodosClientes()
        {
            var usuariosLinhas = File.ReadAllLines(PATH);
            List<Cliente> usuarios = new List<Cliente>();
            foreach (var l in usuariosLinhas)
            {
                    Cliente c = new Cliente();      
                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario", l));
                    c.Nome = ExtrairValorDoCampo("nome", l);
                    c.Email = ExtrairValorDoCampo("email", l);
                    c.Senha = ExtrairValorDoCampo("senha", l);
                    c.Telefone = ExtrairValorDoCampo("telefone", l);
                    c.CPF = ExtrairValorDoCampo("cpf", l);

                    usuarios.Add(c);
            }

            return usuarios;
        }

        private string Preparar(Cliente c)
        {
            return $"tipo_usuario={c.TipoUsuario};nome={c.Nome};email={c.Email};senha={c.Senha};telefone={c.Telefone};cpf={c.CPF}";
        }
}
}