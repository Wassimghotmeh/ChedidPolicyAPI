using ChedidAPIData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIRepository.UserRepository
{

    public class UserRepository : IUserRepository
    {
        private readonly PolicyContext _context;

        public UserRepository(PolicyContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            // Validate user credentials (you should hash the password and compare in a real system)
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user;
        }
    }
}

