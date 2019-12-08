using System;
using System.Collections.Generic;
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

        public List<Suporte> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Suporte> suportes = new List<Suporte>();

            foreach (var l in linhas)
            {
                Suporte s = new Suporte();
                Cliente c = new Cliente();

                c.Nome = ExtrairValorDoCampo("nome", l);
                s.Problema = ExtrairValorDoCampo("problema", l);
                c.Telefone = ExtrairValorDoCampo("telefone", l);                
                c.Email = ExtrairValorDoCampo("email", l);                
                s.Mensagem = ExtrairValorDoCampo("mensagem", l);                
                s.Mensagem = s.Mensagem.Replace("§", "\r\n");
                s.DataDoEnvio = DateTime.Parse(ExtrairValorDoCampo("dataDoEnvio", l));     
                s.Usuario = c;

                suportes.Add(s);
            }
            return suportes;
        }

        private string Preparar(Suporte msg)
        {
            Cliente c = msg.Usuario; 
            return $"nome={c.Nome};problema={msg.Problema};telefone={c.Telefone};email={c.Email};mensagem={msg.Mensagem};dataDoEnvio={msg.DataDoEnvio}";
        }
}
}