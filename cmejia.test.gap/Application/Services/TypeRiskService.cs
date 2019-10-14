using AutoMapper;
using cmejia.test.gap.Application.Interfaces;
using cmejia.test.gap.Application.ViewModel;
using cmejia.test.gap.Domain.Data.Interfaces;
using cmejia.test.gap.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cmejia.test.gap.Application.Services
{
    public class TypeRiskService : ITypeRiskService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;


        public TypeRiskService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<TypeRiskVM>> GetAsync()
        {
            var repository = unitOfWork.GetRepository<TypeRisk>();
            var types = await repository.GetAsync();
            return mapper.Map<List<TypeRiskVM>>(types);
        }
    }
}
