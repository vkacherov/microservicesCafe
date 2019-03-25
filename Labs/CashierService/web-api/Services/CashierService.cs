using System;
using System.Collections.Generic;
using CashierServices.Contracts;
using CashierServices.Models;
using System.Linq;

namespace CashierServices.Services
{
    public class CashierService : ICashierService
    {
        private readonly List<Order> _cashierService;

        public CashierService()
        {
            _cashierService = new List<Order>();
        }

        public Order Add(Order newOrder)
        {
            newOrder.orderid = Guid.NewGuid();
            newOrder.orderdate = DateTime.UtcNow;
            newOrder.status = "pending";
            
            _cashierService.Add(newOrder);

            return newOrder;
        }

        public IEnumerable<Order> GetAllItems()
        {
            return _cashierService;
        }

        public Order GetById(Guid orderid)
        {
            return _cashierService.Where(a => a.orderid == orderid)
                .FirstOrDefault();
        }

        public void Remove(Guid orderid)
        {
            var existing = _cashierService.First(a => a.orderid == orderid);
           
            _cashierService.Remove(existing);
        }
    }
}