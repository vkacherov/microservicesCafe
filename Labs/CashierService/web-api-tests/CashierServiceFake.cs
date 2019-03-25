using System;
using System.Collections.Generic;
using System.Linq;
using CashierServices.Contracts;
using CashierServices.Models;
using Microsoft.Extensions.Options;

namespace CashierServicesTests
{
    class CashierServiceFake : ICashierService
    {
        private readonly List<Order> _cashierService;
        IOptions<ApplicationSettings> _settings;

        public CashierServiceFake(IOptions<ApplicationSettings> settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(_settings));

            _cashierService = new List<Order>()
            {
                new Order() { orderid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    name = "John Smith", phone = "480-000-4567", status = "pending", orderdate = DateTime.UtcNow },
                
                new Order() { orderid = new Guid(),
                    name = "Fred Jones", phone = "617-000-555", status = "pending", orderdate = DateTime.UtcNow },
                
                new Order() { orderid = new Guid(),
                    name = "Susan Berg", phone = "781-000-4567", status = "pending", orderdate = DateTime.UtcNow },
            };
        }

        public IEnumerable<Order> GetAllItems()
        {
            return _cashierService;
        }

        public Order Add(Order newOrder)
        {
            newOrder.orderid = Guid.NewGuid();
            newOrder.orderdate = DateTime.UtcNow;
            
            _cashierService.Add(newOrder);
            return newOrder;
        }

        public Order GetById(Guid id)
        {
            return _cashierService.Where(a => a.orderid == id)
                .FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            var existing = _cashierService.First(a => a.orderid == id);
           _cashierService.Remove(existing);
        }
    }
}