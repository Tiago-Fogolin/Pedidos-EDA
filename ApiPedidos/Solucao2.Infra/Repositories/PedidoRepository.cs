using Microsoft.EntityFrameworkCore;
using Solucao2.Domain;
using Solucao2.Domain.Interfaces;
using Solucao2.Domain.ValueObjects;

namespace Solucao2.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPedidoAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> GetPedidoByIdAsync(Guid id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<List<Pedido>> GetPedidoAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido> InvoicePedidoAsync(Guid id)
        {
            Pedido pedido = await _context.Pedidos.FindAsync(id);
            pedido.Status = PedidoStatus.Faturado;
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> CancelPedidoAsync(Guid id)
        {
            Pedido pedido = await _context.Pedidos.FindAsync(id);
            pedido.Status = PedidoStatus.Cancelado;
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> ShipPedidoAsync(Guid id)
        {
            Pedido pedido = await _context.Pedidos.FindAsync(id);
            pedido.Status = PedidoStatus.Enviado;
            await _context.SaveChangesAsync();
            return pedido;
        }
    }
}
