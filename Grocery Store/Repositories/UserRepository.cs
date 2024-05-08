using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_Store.Models;

namespace Grocery_Store.Repositories
{
    interface UserRepository
    {
        int SignupUser(SignupEntity user);
        SignupEntity LoginUser(LoginEntity user);
        void UpdateUser(LoginEntity user);
        Boolean IsEmailUnique(string email);
    }
}