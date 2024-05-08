using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_Store.Models;

namespace Grocery_Store.Repositories
{
    interface CartRepository
    {
        CartEntity AddToCart(int id,int quantity);
        CartEntity SearchFromCart(int id, List<CartEntity> cart);
        List<CartEntity> RemoveFromCart(int id,List<CartEntity> cart);
    }
}
