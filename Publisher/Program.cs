using System;
using System.Text;
using static System.Console;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //projeto que vai publicar a mensagem
            //abrindo uma conexão com o client .net
            var factory = new ConnectionFactory{ HostName = "localhost" };

            using var connection = factory.CreateConnection();//abrindo a conexão com o rabbit

            using var channel = connection.CreateModel();
                //para utilizar o rabbit, é necessário criar um nó rabbit.
                //conexão esta que será utilizada para manipular todas as operações do mq
            channel.QueueDeclare(queue: "hello_1", //nomeDaFila
             /*declarando uma fila*/ durable: false, //permanece ativa se o servidor reiniciado
                                     exclusive: false, //acessada via conexão atual, excluída ao fechar conexão
                                     autoDelete: false,//será deletada automaticamente ao fim da fila
                                     arguments: null);

                const string message = "Primeiro teste com Rabbit 🐰"; //mensagem postada na fila
                var body = Encoding.UTF8.GetBytes(message);      //codificando em array de bytes


                channel.BasicPublish(exchange: string.Empty,  //publicando a fila
                                         routingKey: "hello_1",
                                         basicProperties: null,
                                         body: body); //corpo da mensagem

                WriteLine($" Enviada: {message}");
            
            ReadLine();
        }
    }
}
