namespace PublisherPedidos.Prioridades
{
    public class PrioridadeService
    {
        private readonly List<IPrioridadeHandler> _handlers;

        public PrioridadeService()
        {
            _handlers = new List<IPrioridadeHandler>
        {
            new PrioridadeCanalVendaHandler(),
            new PrioridadeEntregaProximaHandler(),
            new PrioridadeFlagClienteHandler()
        };
        }

        public byte Calcular(PedidoMessage pedido)
        {
            foreach (var handler in _handlers)
            {
                var resultado = handler.CalcularPrioridade(pedido);
                if (resultado.HasValue)
                { 
                    return resultado.Value;
                }
            }

            return 1;
        }
    }

}
