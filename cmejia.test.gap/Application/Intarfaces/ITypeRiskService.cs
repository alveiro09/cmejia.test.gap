using cmejia.test.gap.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cmejia.test.gap.Application.Interfaces
{
    public interface ITypeRiskService
    {
        Task<List<TypeRiskVM>> GetAsync();
    }
}
