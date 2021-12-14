using PlannerPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Xsl;
using PlannerPlus.Repositories;
using Ardalis.Specification;
using PlannerPlus.Specifications.Master;

namespace PlannerPlus.BusinessLogic
{
    public class MastersService : IMastersService
    {
        private readonly IRepositoryBase<Master> _repository;
        private readonly IRepositoryBase<Service> _serviceRepository;

        public MastersService(IRepositoryBase<Master> repository,IRepositoryBase<Service> serviceRepository)
        {
            _repository = repository;
            _serviceRepository = serviceRepository;
        }
        public async Task AddAsync(Master master)
        {
            if (string.IsNullOrEmpty(master.Name))
            {
                throw new Exception("Wrong name of Master");
            }

            await _repository.AddAsync(master);
            await _repository.SaveChangesAsync();
        }

        public Task<List<Master>> GetAllAsync()
        {
            return _repository.ListAsync();
        }

        public async Task AddMasterServiceAsync(int masterId, int serviceId)
        {
            var masterWithServiceSpec = new MasterWithServicesSpec(masterId);
            var master = await  _repository.GetBySpecAsync(masterWithServiceSpec);
            var service = await _serviceRepository.GetByIdAsync(serviceId);
            if (master == null || service == null)
            {
                throw new Exception("Master or service doesn't exist");
            }
            master.Services.Add(service);
           await _repository.SaveChangesAsync();

        }
        public async Task DeleteAsync(int masterId)
        {
            var master = new Master()
            {
                Id = masterId
            };
            await _repository.DeleteAsync(master);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Master master)
        {
            await _repository.UpdateAsync(master);
            await _repository.SaveChangesAsync();
        }
    }
}
