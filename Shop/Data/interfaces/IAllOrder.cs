using System;
using Shop.Data.Models;

namespace Shop.Data.interfaces
{
    public interface IAllOrder
    {
        void CreateOrder(Order order);
    }
}
