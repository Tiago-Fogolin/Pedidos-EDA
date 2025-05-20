using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace PedidoCriadoSubscriber
{
    public class PedidoCriadoSubscriber
    {
        private const string ExchangeName = "orders_exchange";
        private const string QueueName = "fila_pedido_criado";
        private const string RoutingKey = "order.created";
        private const string ApiUrl = "https://localhost:7031/api/Pedido";

        public void Iniciar()
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://hjnxhbeo:5WUsGd3MD9ALugqkUS_obOmaF3qmofru@jackal.rmq.cloudamqp.com/hjnxhbeo")};

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Topic);

            var args = new Dictionary<string, object>
            {
                { "x-max-priority", 10 }
            };

            channel.QueueDeclare(queue: QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: args);

           
            channel.QueueBind(queue: QueueName,
                              exchange: ExchangeName,
                              routingKey: RoutingKey);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var messageJson = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Recebido: {messageJson}");
                Console.WriteLine($"Prioridade recebida: {ea.BasicProperties.Priority}");

                try
                {
                    using var httpClient = new HttpClient();
                    var content = new StringContent(messageJson, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(ApiUrl, content);
                    Thread.Sleep(500);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Pedido enviado com sucesso para API.");
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao enviar para API: {response.StatusCode}");
                    }

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            };

            channel.BasicConsume(queue: QueueName,
                                 autoAck: false,
                                 consumer: consumer);

            Console.WriteLine("Aguardando mensagens de pedidos criados...");
            Console.ReadLine(); 
        }
    }
}