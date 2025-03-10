using ChedidAPIData;
using ChedidAPIRepository.PolicyRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChedidAPIBusiness.PolicyBusiness
{
    public class PolicyBusiness : IPolicyBusiness
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyBusiness(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public async Task<IEnumerable<Policy>> GetAllPoliciesAsync(int pageNumber, int pageSize)
        {
            return await _policyRepository.GetAllPoliciesAsync(pageNumber, pageSize);
        }

        public async Task<Policy?> GetPolicyByIdAsync(int id)
        {
            return await _policyRepository.GetPolicyByIdAsync(id);
        }

        public async Task AddPolicyAsync(Policy policy)
        {
            _policyRepository.AddPolicyAsync(policy);
        }

        public async Task UpdatePolicyAsync(Policy policy)
        {
             _policyRepository.UpdatePolicyAsync(policy);
        }

        public async Task DeletePolicyAsync(int id)
        {
            _policyRepository.DeletePolicyAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _policyRepository.SaveChangesAsync();
        }
    }
}
