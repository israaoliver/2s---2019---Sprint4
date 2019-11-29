using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class EventoRepository : RepositoryBase
    {
        private const string PATH = "Database/Evento.csv";

        public EventoRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Evento evento)
        {
            var qtdeEvento = File.ReadAllLines(PATH).Length;
            evento.Id = (ulong) ++ qtdeEvento;

            evento.Descricao = evento.Descricao.Replace("\r\n", "§");

            var linha = new string[]{PrepararEventoCSV(evento)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        public string PrepararEventoCSV(Evento e)
        {
            Cliente c = e.Cliente;

            return $"id={e.Id};status={e.Status}nomeEvento={e.NomeEvento};dataEvento={e.DiaDoEvento};servicos={e.Servicos};qtde={e.Quantidade};descricao={e.Descricao}";
        }
    }
}