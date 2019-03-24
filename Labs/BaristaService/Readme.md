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
  
## Prerequisites

* <a href="https://code.visualstudio.com/download">Visual Studio Code</a> with Azure Functions extension (SDK) installed
  
## Step-by-step 
In this lab we will use the Azure Function App to implement the Barista Service. Azure Functions is a serverless compute service that enables you to run code on-demand without having to explicitly provision or manage infrastructure.

Begin by opening the Visual Studio Code in an empty directory. Bring up the command palette (Ctrl+Shift+P) and type "Functions", the command palette will filter the list to show available comands for Azure Functions.
* Select "Create Function..." command and select the local directory (default) to create your function app. Since there is no Function project created yet, you will be asked to initialize it, click "Yes".
* Next you will be asked to pick a language of choice, for this tutorial we will use JavaScript, but feel free to experiment with others. *Note: The code samples provided are JavaScript.* If you are prompted to select runtime, please pick Azure Functions v2.
* The Azure Functions platform offers many templates to get started, since we want our code to execute when the new coffee order is placed in the "Pending Orders" queue, we will use Azure Service Bus Queue trigger.
* Give your function a unique name (e.g. ProcessOrder or BaristaService)
* Now we need to specify the Service Bus service we will be working with. Select "+ New App Setting" and select the Service Bus name from the drop-down.
* Next we need to specify the Queue name we will be monitoring, select "pendingordersqueue".
* Lastly, you will be asked to select a Storage Account to use, select the default from the drop-down.

<img src="./Images/createFunction.gif" width="100%"/>

We now have a basic function that will be triggered when there are new messages added to the "Panding Orders" queue. You can test your function by running it locally in the VS Code:

<img src="./Images/vscodeFunctionDebug.png" width="100%"/>>
