namespace PublisherPedidos
{

    public class PedidoStatus
    {
        public string Valor { get; set; }


        public PedidoStatus(string valor)
        {
            Valor = valor;
        }

        public static PedidoStatus Criado => new("Criado");
        public static PedidoStatus Faturado => new("Faturado");
        public static PedidoStatus Enviado => new("Enviado");
        public static PedidoStatus Cancelado => new("Cancelado");
    }

    public class PedidoMessage
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public int QtdProdutos { get; set; }
        public DateTime DataHora { get; set; }
        public string EnderecoEntg { get; set; }
        public string CanalVenda { get; set; }
        public DateTime DataEntrega { get; set; }
        public bool PedidoPrioritario { get; set; }
        public PedidoStatus Status { get; set; } = PedidoStatus.Criado;
    }
}
