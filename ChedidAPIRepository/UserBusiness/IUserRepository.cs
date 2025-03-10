using ChedidAPIData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIRepository.UserRepository
{
    public interface IUserRepository
    {
        Task<User> AuthenticateUserAsync(string username, string password);
    }
}
