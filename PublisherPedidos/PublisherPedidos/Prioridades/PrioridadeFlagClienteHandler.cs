namespace PublisherPedidos.Prioridades
{
    public class PrioridadeFlagClienteHandler : IPrioridadeHandler
    {
        public byte? CalcularPrioridade(PedidoMessage pedido)
        {
            if (pedido.PedidoPrioritario)
            {
                return 3;
            }

            return null;
        }
    }

}
