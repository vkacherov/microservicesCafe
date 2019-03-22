# Dispatcher Service

## Overview

The Dispatcher Service consumes the "Completed Orders" queue and is responsible for notifiying the customers by sending an SMS text message. Each order in the completed queue should only be consumed and processed by a single Dispatcher.  

![Dispatcher Service](./Images/DispatcherService.png =300x)

## Core Technologies

* Azure Service Bus
* Azure Logic Apps
* Twillio

## Prerequisites

* [Twilio]('https://www.twilio.com/) Account
  
  * You will need a Twilio account ID and authentication token, which you can find on your Twilio dashboard

  * Your credentials authorize your logic app to create a connection and access your Twilio account from your logic app. If you're using a Twilio trial account, you can send SMS only to verified phone numbers.

  * A verified Twilio phone number that can send SMS

  * A verified Twilio phone number that can receive SMS
  
## Implementation

In this lab we will use the Azure Logic App to implement the Dispatcher Service. Azure Logic Apps is a cloud service that helps you automate and orchestrate tasks, business processes, and workflows.

1. Begin by navigating to the [Azure portal]('https://portal.azure.com') and sign in.
2. Onced in the portal, click on the Create Resource button ![createResourcePlus](./Images/createResourcePlus.png =30x) in the left-side control panel.
3. Type in "Logic App" in the search field and click enter. Click the "Create" button at the bottom of the Logic App blade and fillout the required fields: Name, Subscription, Resource Group (select "Use Existing" to keep all lab resource together) and Location and click create.
   
![Create Logic App]('./Images/createLogicApp.gif')

4. Select "When a messge is received in a Service Bus queue" card on the Logic Apps Designer screen. ![](./Images/newLAStart.png =400x)