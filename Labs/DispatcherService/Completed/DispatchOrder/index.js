module.exports = function(context, completedOrderMsg) {
    context.log('JavaScript ServiceBus queue trigger function processed message', completedOrderMsg);

    // In this example the queue item is a JSON string representing an order that contains the name of a
    // customer and a mobile number to send text updates to.
    var msg = "Hello " + completedOrderMsg.name + ", your order is now ready.";

    // Even if you want to use a hard coded message in the binding, you must at least
    // initialize the message binding.
    context.bindings.message = {};

    // A dynamic message can be set instead of the body in the output binding. The "To" number 
    // must be specified in code. 
    context.bindings.message = {
        body : msg,
        to : completedOrderMsg.phone
    };

    context.done();

};