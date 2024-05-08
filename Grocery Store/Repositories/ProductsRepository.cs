using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_Store.Models;

namespace Grocery_Store.Repositories
{
    interface ProductsRepository
    {
        void AddProduct(ProductEntity product);
        ProductEntity GetProduct(int id);
        void UpdateProduct(ProductEntity p);
        void RemoveProduct(int id);
        List<ProductEntity> ShowProducts();
    }
}
