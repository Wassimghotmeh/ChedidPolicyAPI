using ChedidAPIData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIRepository.PolicyRepository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly PolicyContext _context;

        public PolicyRepository(PolicyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllPoliciesAsync(int pageNumber, int pageSize)
        {
            return await _context.Policies
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<Policy?> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies.FindAsync(id);
        }

        public async Task AddPolicyAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
        }

        public async Task UpdatePolicyAsync(Policy policy)
        {
            _context.Policies.Update(policy);
        }

        public async Task DeletePolicyAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy != null)
            {
                _context.Policies.Remove(policy);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Perform your operations here, example:
                    await _context.SaveChangesAsync();

                    // Commit the transaction if everything is successful
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    // Rollback the transaction in case of error
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
