using cmejia.test.gap.Application.Interfaces;
using cmejia.test.gap.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace cmejia.test.gap.Controllers
{
    [Route("api/[controller]")]
    public class PoliciesController : Controller
    {
        private readonly IPolicyService policyService;

        public PoliciesController(IPolicyService policyService)
        {
            this.policyService = policyService;
        }

        [HttpPost()]
        [Produces("application/json")]
        public async Task<IActionResult> CreatePolicy(PolicyVM policy)
        {
            return policyService.CreatePolicy(policy) ?
                    Created("/Policy", "Policy was created") :
                    StatusCode((int)HttpStatusCode.InternalServerError, "Internal error during policy creation");
        }

        [HttpPatch()]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePolicy(PolicyVM policy)
        {
            return policyService.UpdatePolicy(policy) ?
                   Accepted("/Policy", "Policy was updated") :
                    StatusCode((int)HttpStatusCode.InternalServerError, "Internal error during policy creation");
        }

        [HttpGet()]
        [Produces("application/json")]
        public async Task<List<PolicyVM>> GetAsync()
        {
            return await policyService.GetAsync();
        }


        [HttpDelete("{idPolicy}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int idPolicy)
        {
            return await policyService.DeletePolicyAsync(idPolicy) ?
                    Accepted("/Policy", "Policy was Deleted") :
                    StatusCode((int)HttpStatusCode.InternalServerError, "Internal error during policy creation");
        }
    }
}
