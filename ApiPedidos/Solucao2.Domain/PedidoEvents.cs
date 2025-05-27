using Solucao2.Domain.ValueObjects;
using Solucao2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPedidos.Domain
{
    public class PedidoEvents
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PedidoId { get; set; }

        
        public PedidoStatus Status { get; set; }

        
        public DateTime OcorreuEm { get; set; } = DateTime.UtcNow;

        public Pedido Pedido { get; set; }
    }
}
