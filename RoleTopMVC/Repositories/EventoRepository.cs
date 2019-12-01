using System;
using System.Collections.Generic;
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

        public List<Evento> ObeterEventoPorCliente(string emailCliente)
        {
            var eventos = ObterTodos();
            List<Evento> eventosCliente = new List<Evento>();

            int nenhumEvento = 0;
            foreach (var e in eventos)
            {
                if(e.Cliente.Email.Equals(emailCliente))
                {
                    eventosCliente.Add(e);
                    nenhumEvento ++;
                }
            }
            if (nenhumEvento > 0)
            {
                return eventosCliente;
            }else
            {
                return null;
            }
            
        }

        public List<Evento> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Evento> eventos = new List<Evento>();

            foreach (var l in linhas)
            {
                Evento e = new Evento();

                e.Id = ulong.Parse(ExtrairValorDoCampo("id", l));
                e.Status = uint.Parse(ExtrairValorDoCampo("status_evento", l));
                e.NomeEvento = ExtrairValorDoCampo("nome_evento", l);
                e.TipoEvento = ExtrairValorDoCampo("tipo_evento", l);
                e.Cliente.Email = ExtrairValorDoCampo("email_cliente", l);
                e.DiaDoEvento = DateTime.Parse(ExtrairValorDoCampo("data_evento", l));
                e.Quantidade = ExtrairValorDoCampo("qtde", l);
                e.Descricao = ExtrairValorDoCampo("descricao", l);
                e.Descricao = e.Descricao.Replace("§", "\r\n");
                e.DataRegistro = DateTime.Parse(ExtrairValorDoCampo("data_registro", l));

                eventos.Add(e);
            }
            return eventos;
        }

        public Evento ObterPor(ulong id)
        {
            var eTotais = ObterTodos();
            foreach (var e in eTotais)
            {
                if(id.Equals(e.Id))
                {
                    return e;
                }
            }
            return null;
        }

        public bool Atualizar(Evento e)
        {
            var eTotais = File.ReadAllLines(PATH);
            var eCSV = PrepararEventoCSV(e);
            var linhaEvento = -1;
            var resultado = false;

            for (int i = 0; i > eTotais.Length ; i++)
            {
                var IdConvertido = ulong.Parse(ExtrairValorDoCampo("id", eTotais[i]));
                if(e.Id.Equals(IdConvertido))
                {
                    linhaEvento = i;
                    resultado = true;
                    break;
                }
            }
            
            if (resultado)
            {
                eTotais[linhaEvento] = eCSV;
                File.WriteAllLines(PATH, eTotais);
            }
            return resultado;
        
        }
        public string PrepararEventoCSV(Evento e)
        {
            Servicos s = e.Servicos;
            Cliente c = e.Cliente;

            return $"id={e.Id};status_evento={e.Status};data_registro={e.DataRegistro};email_cliente={c.Email};nome_evento={e.NomeEvento};tipo_evento={e.TipoEvento};data_evento={e.DiaDoEvento};servico_nome={s.Nome};servicos_preco={s.Preco};qtde={e.Quantidade};descricao={e.Descricao};";
        }
    }
}