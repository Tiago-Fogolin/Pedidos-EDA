namespace PublisherPedidos.Prioridades
{
    public class PrioridadeEntregaProximaHandler : IPrioridadeHandler
    {
        public byte? CalcularPrioridade(PedidoMessage pedido)
        {
            if ((pedido.DataEntrega - DateTime.Now).TotalDays <= 3)
            {
                return 6;
            }

            return null;
        }
    }
}
