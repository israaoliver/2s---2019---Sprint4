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
            var l = new string[] { Preparar(msg)};
            File.AppendAllLines(PATH, l);

            return true;
        }

        private string Preparar(Suporte msg)
        {
            return $"problema={msg.Problema};mensagem={msg.Mensagem}";
        }
}
}