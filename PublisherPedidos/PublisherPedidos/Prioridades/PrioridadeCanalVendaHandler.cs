namespace PublisherPedidos.Prioridades
{
    public class PrioridadeCanalVendaHandler : IPrioridadeHandler
    {
        public byte? CalcularPrioridade(PedidoMessage pedido)
        {
            if (pedido.CanalVenda?.ToLower() == "shopee")
            {
                return 9;
            }

            return null;
        }
    }
}
