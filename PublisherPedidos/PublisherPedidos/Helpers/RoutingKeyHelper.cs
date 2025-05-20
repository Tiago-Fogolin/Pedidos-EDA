namespace PublisherPedidos.Helpers
{
    public class RoutingKeyHelper
    {
        public static string ObterRoutingKey(PedidoStatus status)
        {
            return status.Valor switch
            {
                "Criado" => "order.created",
                "Faturado" => "order.invoiced",
                "Enviado" => "order.shipped",
                "Cancelado" => "order.canceled",
                _ => "order.generic"
            };
        }
    }
}
