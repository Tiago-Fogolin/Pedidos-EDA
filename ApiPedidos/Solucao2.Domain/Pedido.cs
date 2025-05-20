using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucao2.Domain.ValueObjects;

namespace Solucao2.Domain
{
    public class Pedido
    {

        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public int QtdProdutos { get; set; }
        public DateTime DataHora { get; set; }
        public string EnderecoEntg { get; set; }
        public string CanalVenda { get; set; }
        public DateTime DataEntrega { get; set; }
        public bool PedidoPrioritario { get; set; }
        public PedidoStatus Status { get; set; } = PedidoStatus.Criado;
    }
}
