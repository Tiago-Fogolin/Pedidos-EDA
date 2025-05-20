using Solucao2.Domain;
using Solucao2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao2.Application.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService (IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task CriarPedido(Pedido pedido)
        {
            await _pedidoRepository.AddPedidoAsync(pedido);
        }

        public async Task<Pedido> PegarPedidoPorId(Guid id)
        {
            return await _pedidoRepository.GetPedidoByIdAsync(id);
        }

        public async Task<List<Pedido>> PegarPedidoTodos()
        {
            return await _pedidoRepository.GetPedidoAsync();
        }

        public async Task<Pedido> FaturarPedido(Guid id)
        {
            return await _pedidoRepository.InvoicePedidoAsync(id);
        }

        public async Task<Pedido> CancelarPedido(Guid id)
        {
            return await _pedidoRepository.CancelPedidoAsync(id);
        }

        public async Task<Pedido> EnviarPedido(Guid id)
        {
            return await _pedidoRepository.ShipPedidoAsync(id);
        }
    }
}
