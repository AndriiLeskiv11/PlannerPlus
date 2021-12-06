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
        private readonly IRepository<Service> _repository;

        public ServicesService(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public void Add(Service service)
        {
            if (string.IsNullOrEmpty(service.Name)) 
            {
                throw new Exception("Wrong name of Service");
            }   
            _repository.Create(service);
            _repository.Save();
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _repository.GetAll();
        }
    }
}
