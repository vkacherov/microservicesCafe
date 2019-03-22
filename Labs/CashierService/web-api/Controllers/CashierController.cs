using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CashierServices.Contracts;
using CashierServices.Models;

namespace CashierServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashierServiceController : ControllerBase
    {
        private readonly ICashierService _service;

        public CashierServiceController(ICashierService service)
        {
            _service = service;
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
        public ActionResult Post([FromBody] Order value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _service.Add(value);
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
