# Cashier Service

 <img src="./Images/CashierService.png" width="300px"/> 
  
  The Cashier Service is responisble for recieving orders via a RESTful API endpoint `[POST]/api/orders` and storing the received orders in the "Pending Orders" queue. Each order in the pending queue should only be consumed and processed by a single Barista Service. 
  The order message will adhere to the following minimum schema:

  ```
    {
        "name": "Joe",
        "phone": "(123)345-6789",
        "status": "PENDING"
    }
  ```  
## Core Technologies

* <a href="https://docs.microsoft.com/en-us/azure/service-bus-messaging">Azure Service Bus</a>
* <a href="https://docs.microsoft.com/en-us/azure/app-service">Azure App Services</a>
  
## Step-by-step 

* Comming Soon

## Next Steps

* <a href="/Labs/BaristaService/Readme.md" class="myButton">Barista Service and Azure Functions</a>
  
