using cmejia.test.gap.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cmejia.test.gap.Application.Interfaces
{
    public interface IPolicyService
    {
        bool CreatePolicy(PolicyVM PolicyVM);

        bool UpdatePolicy(PolicyVM PolicyVM);

        Task<List<PolicyVM>> GetAsync();

        Task<bool> DeletePolicyAsync(int idPolicy);
    }
}
