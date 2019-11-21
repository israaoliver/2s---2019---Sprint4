using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.Repositories
{
    public class PedidoRepository : RepositoryBase
    {
        private const string PATH = "Database/Pedidos.csv";

        public PedidoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pedido pedido)
        {
            var linha = new string[] {PrepararPedidoCSV(pedido)};
            File.AppendAllLines(PATH, linha);
            return true;

        }
        
        public List<Pedido> ObterTodosPorCliente(string emailCliente)
        {
            var pedidos = ObterTodos();
            List<Pedido> pedidosCliente = new List<Pedido>();

            foreach (var pedido in pedidos)
            {
                if(pedido.Cliente.Email.Equals(emailCliente))
                {
                    pedidosCliente.Add(pedido);
                }
            }
            return pedidosCliente;
        }

        public List<Pedido> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Pedido> pedidos = new List<Pedido>();
            foreach (var l in linhas)
            {
                Pedido p = new Pedido();

                p.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", l);
                p.Cliente.Endereco = ExtrairValorDoCampo("cliente_endereco", l);
                p.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", l);
                p.Cliente.Email = ExtrairValorDoCampo("cliente_email", l);
                p.Hamburguer.Nome = ExtrairValorDoCampo("hamburguer_nome", l);
                p.Hamburguer.Preco = double.Parse(ExtrairValorDoCampo("hamburguer_preco", l));
                p.Shake.Nome = ExtrairValorDoCampo("shake_nome", l);
                p.Shake.Preco = double.Parse(ExtrairValorDoCampo("shake_preco", l));
                p.PrecoTotal = double.Parse(ExtrairValorDoCampo("preco_total", l));
                p.DataDoPedido = DateTime.Parse(ExtrairValorDoCampo("data_pedido", l));

                pedidos.Add(p);
            }
            return pedidos;
        }

        

        private string PrepararPedidoCSV(Pedido p)
        {
            Cliente c = p.Cliente;
            Hamburguer h = p.Hamburguer;
            Shake s = p.Shake;

            return $"cliente_nome={c.Nome};cliente_endereco={c.Endereco};cliente_telefone={c.Telefone};cliente_email={c.Email};hamburguer_nome={h.Nome};hamburguer_preco={h.Preco};shake_nome={s.Nome};shake_preco={s.Preco};data_pedido={p.DataDoPedido};preco_total={p.PrecoTotal}";
        }
    }
}