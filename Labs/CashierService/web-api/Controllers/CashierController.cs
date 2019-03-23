using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using CashierServices.Contracts;
using CashierServices.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace CashierServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashierServiceController : ControllerBase
    {
        private readonly ICashierService _service;
        private IOptions<ApplicationSettings> _settings;
        private readonly IMessageQueueService _messageQueue;

        public CashierServiceController(ICashierService service, 
            IMessageQueueService messageQueueService,  
            IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
            _service = service;
            _messageQueue = messageQueueService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> Get(Guid orderid)
        {
            var item = _service.GetById(orderid);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _service.Add(newOrder);

            //Send the message to the queue
            _messageQueue.SendMessage(JsonConvert.SerializeObject(newOrder));
 
            return CreatedAtAction("Get", new { id = item.orderid }, item);
        }

        [HttpDelete("{orderid}")]
        public ActionResult Remove(Guid orderId)
        {
            var existingItem = _service.GetById(orderId);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.Remove(orderId);
            return Ok();
        }
    }
}
