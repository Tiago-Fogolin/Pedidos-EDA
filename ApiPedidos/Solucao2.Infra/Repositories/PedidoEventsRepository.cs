using ApiPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Solucao2.Domain;
using Solucao2.Domain.Interfaces;
using Solucao2.Domain.ValueObjects;

namespace Solucao2.Infra.Repositories
{
    public class PedidoEventsRepository : IPedidoEventsRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoEventsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEventoAsync(PedidoEvents evento)
        {
            await _context.EventosPedidos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PedidoEvents>> GetEventosByPedidoId(Guid pedidoId)
        {
            return await _context.EventosPedidos
                .Where(e => e.PedidoId == pedidoId)
                .Include(e => e.Pedido)
                .OrderBy(e => e.OcorreuEm)
                .ToListAsync();
        }
    }
}
