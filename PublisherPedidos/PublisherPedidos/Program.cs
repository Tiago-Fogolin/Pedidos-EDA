
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
                    DataHora = DateTime.Now.AddHours(-3),
                    EnderecoEntg = "Rua das Flores, 45",
                    Status = PedidoStatus.Criado,
                    CanalVenda = "mercado livre",
                    DataEntrega = DateTime.Now.AddDays(2)
                },
                new PedidoMessage
                {
                    Usuario = "bob@email.com",
                    QtdProdutos = 5,
                    DataHora = DateTime.Now.AddHours(-2),
                    EnderecoEntg = "Av. Central, 123",
                    Status = PedidoStatus.Criado,
                    CanalVenda = "loja",
                    DataEntrega = DateTime.Now.AddDays(3)
                },
                new PedidoMessage
                {
                    Usuario = "carol@email.com",
                    QtdProdutos = 1,
                    DataHora = DateTime.Now.AddHours(-1),
                    EnderecoEntg = "Praça Nova, 99",
                    Status = PedidoStatus.Criado,
                    CanalVenda = "shopee",
                    DataEntrega = DateTime.Now.AddDays(1)
                },
                new PedidoMessage
                {
                    Usuario = "daniel@email.com",
                    QtdProdutos = 3,
                    DataHora = DateTime.Now.AddMinutes(-45),
                    EnderecoEntg = "Rua dos Pinheiros, 78",
                    Status = PedidoStatus.Criado,
                    CanalVenda = "site oficial",
                    DataEntrega = DateTime.Now.AddDays(1)
                },
                new PedidoMessage
                {
                    Usuario = "elisa@email.com",
                    QtdProdutos = 4,
                    DataHora = DateTime.Now.AddMinutes(-15),
                    EnderecoEntg = "Rua Aurora, 12",
                    Status = PedidoStatus.Criado,
                    CanalVenda = "app mobile",
                    DataEntrega = DateTime.Now.AddDays(4),
                    PedidoPrioritario = true
                }
            };
        }
    }
}
