# Simple remote http tester

![Diagram](https://github.com/LeonLdv/RemoteHttpTester/blob/master/doc/architecture-diagram.png)

This simple application for demonstration microservices architecture by using the service bus RabbitMq(Masstransit), Web API Rest, CQRS and NoSql (MongoDB).

The application provides the ability to test externals Web API  endpoints,  specify the number of random requests, get statistic requests data by coreletionId.

Request Receiver Service Web API - gets requests and sends to service bus queue "RequestsExecutor" by using the Direct exchange.

Requests Executor Service - consumes  "RequestsExecutor"  queue messages, executes http requests, publishes  RequestTaskExecutedEvent event with statistic requests data by using Topic exchange. The service can be deployed in several instances. 

Statistics Service Web API -  listener of RequestTaskExecutedEvent,
saves statistic request data to MongoDB, provides get statistics by REST. The service is using CQRS approach.  

Each of the services is used simple architecture since services logic is simple and services is tiny. 

In progress: Unit and integration tests, containerization, clusterization, logging exceptions via middleware, authentification and so on. 

