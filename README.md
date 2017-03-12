# delivery-service-management
Delivery management application implementing microservices architecture.
Using :
- Net Core
- MassTransit
- RabbitMQ
- Docker


Useful tips : 

Run RabbitMQ container images:
docker run -d --name rabbit --hostname my-rabbit -p 5672:5672 -p 15672:15672 -v rabbitvolume:/var/lib/rabbitmq rabbitmq:3-management
- Port 5672 used for messaging
- Port 15672 used for management console plugin


