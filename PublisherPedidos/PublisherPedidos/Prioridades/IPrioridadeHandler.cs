namespace PublisherPedidos.Prioridades
{
    public interface IPrioridadeHandler
    {
        byte? CalcularPrioridade(PedidoMessage pedido);
    }
}
