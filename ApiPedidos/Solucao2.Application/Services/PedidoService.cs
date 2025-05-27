using ApiPedidos.Domain;
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
        private readonly IPedidoEventsRepository _pedidoEventRepository;

        public PedidoService (IPedidoRepository pedidoRepository, IPedidoEventsRepository pedidoEventRepository)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoEventRepository = pedidoEventRepository;
        }

        public async Task CriarPedido(Pedido pedido)
        {
            await _pedidoRepository.AddPedidoAsync(pedido);

            var evento = new PedidoEvents
            {
                PedidoId = pedido.Id,
                Status = pedido.Status,
                OcorreuEm = DateTime.UtcNow
            };

            await _pedidoEventRepository.AddEventoAsync(evento);
        }

        public async Task<List<PedidoEvents>> ObterHistoricoDeEventos(Guid pedidoId)
        {
            return await _pedidoEventRepository.GetEventosByPedidoId(pedidoId);
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
