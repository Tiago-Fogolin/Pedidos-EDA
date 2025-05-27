using ApiPedidos.Domain;

namespace Solucao2.Domain.Interfaces
{
    public interface IPedidoEventsRepository
    {
        Task AddEventoAsync(PedidoEvents evento);
        Task<List<PedidoEvents>> GetEventosByPedidoId(Guid pedidoId);

    }
}
