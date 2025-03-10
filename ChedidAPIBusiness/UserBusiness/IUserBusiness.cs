using ChedidAPIData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIBusiness.UserBusiness
{
    public interface IUserBusiness
    {
        Task<User> AuthenticateUserAsync(string username, string password);
    }
}
