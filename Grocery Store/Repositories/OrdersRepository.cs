using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_Store.Models;

namespace Grocery_Store.Repositories
{
    interface OrdersRepository
    {
        void LoadOrders(int id);
        void PlaceOrder(OrderEntity order);
    }
}
