# Simple remote http tester

![Diagram](https://github.com/LeonLdv/RemoteHttpTester/blob/master/doc/architecture-diagram.png)



This simple application demonstrates microservices architecture by using the service bus RabbitMq(MassTransit), Web API Rest, CQRS + Mediator, and NoSQL (MongoDB).

he application provides the ability to test external Web API endpoints, specify the number of random requests, and get statistics of requests data by coreletionId.

The example is using simple architecture since each service is tiny.

**Request Receiver Service Web API** - gets requests and sends them to the service bus queue "RequestsExecutor" by using the Direct exchange..

**Requests Executor Service** - consumes "RequestsExecutor" queue messages, executes HTTP requests, and publishes RequestTaskExecutedEvent event with statistic requests data by using Topic exchange. The service can be deployed in several instances. 

**Statistics Service Web API** - listener of RequestTaskExecutedEvent,
saves statistic request data to MongoDB, provides get statistics by REST. The service is using CQRS approach.  

Each of the services is used simple architecture since services logic is simple and services is tiny. 

**In progress:** unit and integration tests, containerization, clusterization, logging exceptions via middleware, authentification, removing redundant assemblies to make services tinier, and so on.
