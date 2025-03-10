using ChedidAPIData;
using ChedidAPIRepository.PolicyRepository;
using ChedidAPIRepository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIBusiness.UserBusiness
{
    public class UserBusiness: IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            return await _userRepository.AuthenticateUserAsync(username, password);
        }
    }
}
