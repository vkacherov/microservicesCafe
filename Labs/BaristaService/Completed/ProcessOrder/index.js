module.exports = async function(context, pendingQueueMsg) {
    context.log('JavaScript ServiceBus queue trigger function processed message', pendingQueueMsg);

    //
    // The service logic is here 
    // For now just set the staus to completed and drop it in the completed queue
    //
    if( pendingQueueMsg ) {
        // Wait 5s to simulate barista doing some work
        let sleep = ms => new Promise( resolve => setTimeout(resolve, ms));
        await sleep(5000);

        pendingQueueMsg.status = "COMPLETED";
        context.log('Order completed, writing to completed orders queue: '+ JSON.stringify(pendingQueueMsg));
        context.bindings.completedQueue = pendingQueueMsg;
    }
};