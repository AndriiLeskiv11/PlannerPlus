using Ardalis.Specification;
using PlannerPlus.Models;
using PlannerPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerPlus.BusinessLogic
{
    public class ServicesService : IServicesService
    {
        private readonly IRepositoryBase<Service> _repository;

        public ServicesService(IRepositoryBase<Service> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Service service)
        {
            if (string.IsNullOrEmpty(service.Name)) 
            {
                throw new Exception("Wrong name of Service");
            }   
           await _repository.AddAsync(service);
           await _repository.SaveChangesAsync();
        }

        public Task<List<Service>> GetAllServicesAsync()
        {
            return _repository.ListAsync();
        }
    }
}
