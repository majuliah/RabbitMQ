using System;
using System.Text;
using static System.Console;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();//criando canal da conexão

            channel.QueueDeclare(queue: "hello_1", //declarando a fila na qual vamos consumir a mensagem
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel); //solicita a entrega das mensagens de forma assincrona e fornece um retorno de chamada

            consumer.Received += (model, ea) => //recebe a mensagem da fila e converte em string
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                WriteLine($" Recebida: {message}");
            };
            channel.BasicConsume(queue: "hello_1", //indicando o consumo da mensagem
                                autoAck: true,
                                consumer: consumer);
            ReadLine();
        }
    }
}
