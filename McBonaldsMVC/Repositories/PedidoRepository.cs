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
            /** 
            var linhas = File.ReadAllLines(PAHT);
            var quantidadePedidos = linhas.Length */ // todo: forma alternativa e detalhada de medir o tamanho da linha especifica
            var quantidadePedidos = File.ReadAllLines(PATH).Length; // todo : forma direta de fazer
            pedido.Id = (ulong) ++quantidadePedidos;
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
                
                p.Id = ulong.Parse(ExtrairValorDoCampo("id", l));
                p.Status = uint.Parse(ExtrairValorDoCampo("status_pedido", l));
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

        public Pedido ObterPor(ulong id)
        {
            var pedidosTotais = ObterTodos();
            foreach (var p in pedidosTotais)
            {
                if(id.Equals(p.Id))
                {
                    return p;
                }
            }
            return null;
        }
        
        public bool Atualizar(Pedido p)
        {
            var pedidosTotais = File.ReadAllLines(PATH);
            var pedidoCSV = PrepararPedidoCSV(p);
            var linhaPedido = -1;
            var resultado = false;
            
            for (int i = 0; i < pedidosTotais.Length; i++)
            {
                var idConvertido =  ulong.Parse(ExtrairValorDoCampo("id", pedidosTotais[i]));
                if(p.Id.Equals(idConvertido))
                {
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado)
            {
                pedidosTotais[linhaPedido] = pedidoCSV;
                File.WriteAllLines(PATH, pedidosTotais);
            }

            return resultado;
        }
        private string PrepararPedidoCSV(Pedido p)
        {
            Cliente c = p.Cliente;
            Hamburguer h = p.Hamburguer;
            Shake s = p.Shake;

            return $"id={p.Id};status_pedido={p.Status};cliente_nome={c.Nome};cliente_endereco={c.Endereco};cliente_telefone={c.Telefone};cliente_email={c.Email};hamburguer_nome={h.Nome};hamburguer_preco={h.Preco};shake_nome={s.Nome};shake_preco={s.Preco};data_pedido={p.DataDoPedido};preco_total={p.PrecoTotal}";
        }
    }
}