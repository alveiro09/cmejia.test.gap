using cmejia.test.gap.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cmejia.test.gap.Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientVM>> GetAsync();
    }
}
