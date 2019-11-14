using System.Diagnostics;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.Repositories
{
    public class PedidoRepository
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

        private string PrepararPedidoCSV(Pedido p)
        {
            Cliente c = p.Cliente;
            Hamburguer h = p.Hamburguer;
            Shake s = p.Shake;

            return $"cliente_nome = {c.Nome};cliente_endereco = {c.Endereco}; cliente_telefone = {c.Telefone}; cliente_email = {c.Email}; hamburguer_nome = {h.Nome}; hamburguer_preco = {h.Preco}; shake_nome = {s.Nome}; shake_preco = {s.Preco}; data_Pedido = {p.DataDoPedido}; preco_total = {p.PrecoTotal}";
        }
    }
}