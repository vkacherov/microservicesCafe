
# Cashier Service

 <img src="./Images/CashierService.png" width="300px/> 
  
  The Cashier Service is responisble for recieving orders via a RESTful API endpoint `[POST]/api/CashierService` and storing the received orders in the "Pending Orders" queue. Each order in the pending queue should only be consumed and processed by a single Barista Service. 
  The order message will adhere to the following minimum schema:

  ```
    {
        "name": "Joe",
        "phone": "(123)345-6789"
    }
  ```  
## Core Technologies

* <a href="https://docs.microsoft.com/en-us/azure/service-bus-messaging">Azure Service Bus</a>
* <a href="https://docs.microsoft.com/en-us/azure/app-service">Azure App Services</a>
* <a href="https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-2-2">.Net Core 2.2</a>
* <a href="https://swagger.io/">OpenAPI</a>

## Prerequisites

* <a href="https://code.visualstudio.com/download">Visual Studio Code</a>
* <a href="https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account">Azure Account Extension for VSCode</a>
* <a href="https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureappservice">Azure App Service Extension for VSCode</a>
* <a href="https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp">C# Extension</a>

## Step-by-step 
In this lab we will build and deploy the Cashier Service to an Azure Web App.  

* In VSCode, open the web-api folder found under the Labs/CashierService. 
	* Note: VSCode may prompt you to restore packages associated with this service

<img src="./Images/Screen1.png" width="600px"/>

* To verify everything is working, press F5 and start debugging. You should get a blank screen.  By adding /swagger to the end of the URL will give you the default swagger page.

<img src="./Images/Screen2.png" width="600px"/>

* Next, we'll add local settings files to allow for local debugging.




Add appsettings.json & appsettings.Development.json

## Next Steps

* <a href="/Labs/BaristaService/Readme.md" class="myButton">Barista Service and Azure Functions</a>
  
