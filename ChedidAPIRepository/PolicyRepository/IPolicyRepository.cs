using ChedidAPIData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIRepository.PolicyRepository
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetAllPoliciesAsync(int pageNumber, int pageSize);
        Task<Policy?> GetPolicyByIdAsync(int id);
        Task AddPolicyAsync(Policy policy);
        Task UpdatePolicyAsync(Policy policy);
        Task DeletePolicyAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
