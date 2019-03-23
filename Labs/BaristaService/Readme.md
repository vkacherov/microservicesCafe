# Barista Service

 <img src="./Images/BaristaService.png" width="300px"/> 
  
  The Barista Service is responisble for consuming the orders from the "Pending Orders" queue, making the order and finally putting the completed orders in the "Completed Orders" queue. 
  The order message will adhere to the following minimum schema:

  ```
    {
        "name": "Joe",
        "phone": "(123)345-6789",
        "status": "COMPLETED"
    }
  ```  
## Core Technologies

* <a href="https://docs.microsoft.com/en-us/azure/service-bus-messaging/">Azure Service Bus</a>
* <a href="https://docs.microsoft.com/en-us/azure/azure-functions/">Azure Functions</a>
  
## Step-by-step 
