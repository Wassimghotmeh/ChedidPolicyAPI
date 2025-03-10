using ChedidAPIData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIData
{
    public class PolicyContext : DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Policy> Policies { get; set; }
    }
}
