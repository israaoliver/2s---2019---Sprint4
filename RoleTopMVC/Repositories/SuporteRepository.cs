using System.Net;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class SuporteRepository : RepositoryBase
    {
        private const string PATH = "Database/Suporte.csv";

        public SuporteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Suporte msg)
        {
            msg.Mensagem = msg.Mensagem.Replace("\r\n", "§"); // todo: tira a quebra de linha que o "enter" que o usuario aperta
            var l = new string[] {Preparar(msg)};
            File.AppendAllLines(PATH, l);

            return true;
        }

        private string Preparar(Suporte msg)
        {
            Cliente c = msg.Usuario; 
            return $"nome={c.Nome};problema={msg.Problema};telefone={c.Telefone};email={c.Email};mensagem={msg.Mensagem};dataDoEnvio={msg.DataDoEnvio}";
        }
}
}