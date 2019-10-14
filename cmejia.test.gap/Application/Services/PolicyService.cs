using AutoMapper;
using cmejia.test.gap.Application.Interfaces;
using cmejia.test.gap.Application.ViewModel;
using cmejia.test.gap.Domain.Data.Interfaces;
using cmejia.test.gap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmejia.test.gap.Application.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public PolicyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public bool CreatePolicy(PolicyVM policyVM)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Policy>();
                Policy policy = mapper.Map<Policy>(policyVM);
                repository.Create(policy);
                return unitOfWork.Commit() > 0;
            }
            catch (Exception exc)
            {

                throw new Exception($"Error creating a Policy. { exc.Message}");
            }
        }

        public async Task<bool> DeletePolicyAsync(int idPolicy)
        {
            var repository = unitOfWork.GetRepository<Policy>();
            var policy = (await repository.GetAsync(predicate: src => src.PolicyId.Equals(idPolicy))).FirstOrDefault();
            repository.Delete(policy);
            return unitOfWork.Commit() > 0;
        }

        public async Task<List<PolicyVM>> GetAsync()
        {
            throw new NotImplementedException();
            //var repository = unitOfWork.GetRepository<Policy>();
            //var policys = await repository.GetAsync(include: source => source.Include(src => src.Client).Include(src => src.TypeCovering).Include(src => src.TypeRisk));
            //return mapper.Map<List<PolicyVM>>(policys);
        }

        public bool UpdatePolicy(PolicyVM policyVM)
        {
            try
            {
                var repository = unitOfWork.GetRepository<Policy>();
                Policy policy = mapper.Map<Policy>(policyVM);
                repository.Update(policy);
                return unitOfWork.Commit() > 0;
            }
            catch (Exception exc)
            {

                throw new Exception($"Error updating a Policy. { exc.Message}");
            }
        }
    }
}
