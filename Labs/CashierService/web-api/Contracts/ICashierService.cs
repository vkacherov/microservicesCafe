using System;
using System.Collections.Generic;
using CashierServices.Models;

namespace CashierServices.Contracts
{
    public interface ICashierService
    {
        IEnumerable<Order> GetAllItems();
        Order Add(Order newItem);
        Order GetById(Guid orderId);
        void Remove(Guid orderId);
    }
}