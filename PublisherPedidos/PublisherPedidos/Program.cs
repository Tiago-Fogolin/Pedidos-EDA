
using PublisherPedidos.Prioridades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherPedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simulando busca de pedidos em uma API externa...");

            var pedidosSimulados = ObterPedidosExternos();

            var prioridadeService = new PrioridadeService();

            foreach (var pedido in pedidosSimulados)
            {
                //Thread.Sleep(500);

                byte prioridade = prioridadeService.Calcular(pedido);
                Console.WriteLine("Prioridade: " + prioridade);

                Publisher.PublishPedidoMessage(pedido, prioridade); 
            }

            Console.WriteLine("Todos os pedidos foram enviados.");
        }

        static List<PedidoMessage> ObterPedidosExternos()
        {
            return new List<PedidoMessage>
        {
            new PedidoMessage
            {
                Usuario = "alice@email.com",
                QtdProdutos = 2,
                DataHora = DateTime.Now.AddMinutes(-30),
                EnderecoEntg = "Rua das Flores, 45",
                Status = PedidoStatus.Criado,
                CanalVenda = "mercado livre"
            },
            new PedidoMessage
            {
                Usuario = "bob@email.com",
                QtdProdutos = 5,
                DataHora = DateTime.Now.AddMinutes(-10),
                EnderecoEntg = "Av. Central, 123",
                Status = PedidoStatus.Criado,
                CanalVenda = "loja"
            },
            new PedidoMessage
            {
                Usuario = "carol@email.com",
                QtdProdutos = 1,
                DataHora = DateTime.Now,
                EnderecoEntg = "Praça Nova, 99",
                Status = PedidoStatus.Criado,
                CanalVenda = "shopee"
            }
        };
        }
    }
}
