namespace Solucao2.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task AddPedidoAsync(Pedido pedido);
        Task<Pedido> GetPedidoByIdAsync(Guid id);
        Task<List<Pedido>> GetPedidoAsync();
        Task<Pedido> InvoicePedidoAsync(Guid id);
        Task<Pedido> CancelPedidoAsync(Guid id);
        Task<Pedido> ShipPedidoAsync(Guid id);
    }
}
