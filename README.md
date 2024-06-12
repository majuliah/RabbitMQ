## Introdução ao RabbitMQ :rabbit:

#### Este repositório possui um exemplo simples do consumo do serviço de mensageria RabbitMQ através de aplicativo de console.



## Contextualizando 

#### RabbitMQ é um servidor de mensageria open source, implementado para suportar mensageria no protocolo AMQP - Advanced Message Queuing Protocol. Ele lida com tráfego de mensagens de forma rápida e confiável além de ser compatível com diversas linguagens de programação. Ele gerencia filas de mensagens, aceita e as passa adiante.

####  Neste exemplo, será feita uma comunicação entre duas soluções (.NET) para enviar a mensagem "Hello World".

![HelloWorldQueueing](https://github.com/majuliah/RabbitMQ/blob/main/imgs/simpleExample.png?raw=true)

##### P é o produtor que significa enviar. Um programa que envia mensagens é um produtor.

##### A fila é o conteúdo da mensagem que está sendo enviado. Mesmo sendo fluída dentro da aplicação, o conteúdo só pode ser armazenado dentro de uma fila rabbitMQ.

##### C é o consumidor, quem vai receber a mensagem. Ele espera a chegada dela.



