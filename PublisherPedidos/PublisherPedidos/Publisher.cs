
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using PublisherPedidos.Helpers;
using System.Text.Json.Serialization;

namespace PublisherPedidos
{
    public class Publisher
    {
        private const string QueueName = "order_queue";

        public static void PublishPedidoMessage(PedidoMessage messageObject, byte priority)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://hjnxhbeo:5WUsGd3MD9ALugqkUS_obOmaF3qmofru@jackal.rmq.cloudamqp.com/hjnxhbeo")};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var args = new Dictionary<string, object>
                {
                    { "x-max-priority", 10 }
                };
                channel.QueueDeclare(queue: QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: args);

                var messageJson = JsonSerializer.Serialize(messageObject);
                var body = Encoding.UTF8.GetBytes(messageJson);

                string exchangeName = "orders_exchange";

                channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic);

                var routingKey = RoutingKeyHelper.ObterRoutingKey(messageObject.Status);

                var properties = channel.CreateBasicProperties();
                properties.Priority = priority;

                channel.BasicPublish(
                        exchange: exchangeName,
                        routingKey: routingKey,
                        basicProperties: properties,
                        body: body
                );

                Console.WriteLine($"Enviado: {messageJson}");
            }
        }
    }
}