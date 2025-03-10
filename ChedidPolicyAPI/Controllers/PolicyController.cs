using ChedidAPIBusiness.PolicyBusiness;
using ChedidAPIData;
using ChedidAPIBusiness.PolicyBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChedidPolicyAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyBusiness _policyBusiness;

        public PoliciesController(IPolicyBusiness policyBusiness)
        {
            _policyBusiness = policyBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetAllPolicies([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var policies = await _policyBusiness.GetAllPoliciesAsync(pageNumber, pageSize);
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicyById(int id)
        {
            var policy = await _policyBusiness.GetPolicyByIdAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            return Ok(policy);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePolicy(Policy policy)
        {
            await _policyBusiness.AddPolicyAsync(policy);
            await _policyBusiness.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPolicyById), new { id = policy.Id }, policy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, Policy policy)
        {
            var existingPolicy = await _policyBusiness.GetPolicyByIdAsync(id);
            if (existingPolicy == null)
            {
                return NotFound();
            }

            existingPolicy.Name = policy.Name;
            existingPolicy.Description = policy.Description;
            existingPolicy.EffectiveDate = policy.EffectiveDate;
            existingPolicy.ExpiryDate = policy.ExpiryDate;

            await _policyBusiness.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            await _policyBusiness.DeletePolicyAsync(id);
            await _policyBusiness.SaveChangesAsync();
            return NoContent();
        }
    }
}
