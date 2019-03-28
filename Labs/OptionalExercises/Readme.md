# Optional Exercises
This section contains a few ideas for expanding on what was done in the main lab. These are provided as pointers rather than step by step exercises.

* Utilize Key Vault and Service Principals to store secrets such as the Service Bus connection string in your services.
* Incorproate DevOps to create a CI/CD pipeline to fully automate deployment of all services.
* Incorporate eventing to allow the services to track the status changes of the order.
* Implement API management to handle security, caching, versioning, routing and API sharing. 
* Add monitoring and alerting to the services track usage, faults and other application specific metrics.
* Containerize the Cashier Service to run inside of Azure Kubernetes, Azure App Service or Azure Container Instance.
* How would scaling be done in each of the services?  Implement an appropriate scale plan to handle large loads and also be cost effective.
* Incorporate a resiliency plan to handle datacenter or regional outages, design patters like circuit breaker and other capabilities to make your services resilient.
