using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao2.Domain.ValueObjects
{
    public class PedidoStatus
    {
        public static readonly PedidoStatus Criado = new("Criado");
        public static readonly PedidoStatus Faturado = new("Faturado");
        public static readonly PedidoStatus Enviado = new("Enviado");
        public static readonly PedidoStatus Cancelado = new("Cancelado");

        public string Valor { get; private set; }

        private PedidoStatus() { }
        public PedidoStatus(string valor)
        {
            Valor = valor;
        }

        public override string ToString() => Valor;

        public bool PodeFaturar() => this == Criado;
        public bool PodeEnviar() => this == Faturado;
    }
}
