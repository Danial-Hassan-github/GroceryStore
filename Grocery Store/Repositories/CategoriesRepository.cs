using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Grocery_Store.Models;
namespace Grocery_Store.Repositories
{
    interface CategoriesRepository
    {
        void AddCategory(CategoryEntity category);
        CategoryEntity GetCategory(int id);
        void UpdateCategory(CategoryEntity c);
        void RemoveCategory(int id);
        List<SelectListItem> GetCategories();
    }
}
