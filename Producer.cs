using Confluent.Kafka;

// Kafka sample: producer publishing an order event to a topic.
public class OrderEventProducer
{
    private readonly IProducer<string, string> _producer;
    public OrderEventProducer(string bootstrap) => _producer = new ProducerBuilder<string, string>(new ProducerConfig { BootstrapServers = bootstrap }).Build();
    public Task ProduceAsync(string orderId, string json) => _producer.ProduceAsync("orders", new Message<string, string> { Key = orderId, Value = json });
}
