using AutoMapper;
using cmejia.test.gap.Application.Interfaces;
using cmejia.test.gap.Application.ViewModel;
using cmejia.test.gap.Domain.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cmejia.test.gap.Application.Services
{
    public class ClientService: IClientService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ClientService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<ClientVM>> GetAsync()
        {
            var repository = unitOfWork.GetRepository<Domain.Models.Client>();
            var Clientes = await repository.GetAsync();
            return mapper.Map<List<ClientVM>>(Clientes);
        }
    }
}
