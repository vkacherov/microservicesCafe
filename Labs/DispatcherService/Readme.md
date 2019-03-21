# Dispatcher Service

## Overview
 
The Dispatcher Service consumes the "Completed Orders" queue and is responsible for notifiying the customers by sending an SMS text message. Each order in the completed queue should only be consumed and processed by a single Dispatcher.  

![Dispatcher Service](./Images/DispatcherService.png =400x)

## Core Technologies

* Azure Service Bus
* Azure Logic Apps
  
## Implementation

In this lab we will use the Azure Logic App to implement the Dispatcher Service. Azure Logic Apps is a cloud service that helps you automate and orchestrate tasks, business processes, and workflows.