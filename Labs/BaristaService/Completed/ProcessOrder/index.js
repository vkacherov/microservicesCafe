module.exports = function(context, pendingQueueMsg) {
    context.log('JavaScript ServiceBus queue trigger function processed message', pendingQueueMsg);

    //
    // The service logic is here 
    // For now just set the staus to completed and drop it in the completed queue
    //
    if( pendingQueueMsg ) {
        pendingQueueMsg.status = "COMPLETED";
        context.log('Order completed, writing to completed orders queue: '+ JSON.stringify(pendingQueueMsg));
        context.bindings.completedQueue = pendingQueueMsg;
    }
    context.done();
};