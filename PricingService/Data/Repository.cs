using PricingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricingService.Data
{
    public class Repository : IRepository
    {
        public PricingServiceDbContext _context;

        public Repository(PricingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(int customerId) =>
            new Customer(customerId, 10, new DateTime(2019, 09, 20), new DateTime(2019, 10, 01));
            // _context.Customers.FirstOrDefault(x => x.Id == customerId);

        public async Task<Discount> GetDiscountByCustomerId(int customerId) =>
           new Discount(1, 0.2m, new DateTime(2019, 09, 22), new DateTime(2019, 09, 24), customerId);
            // _context.Discounts.FirstOrDefault(x => x.CustomerId == customerId);

        public async Task<IEnumerable<Service>> GetServicesByCustomerId(int customerId) =>
            CreateServiceList().Where(x => x.CustomerId == customerId);
            //_context.Services.Where(x => x.Id == customerId).ToList();

        private List<Service> CreateServiceList() =>
            new List<Service>()
            {
                new Service(1, ServiceName.ServiceA, 0.2m, 1),
                new Service(2, ServiceName.ServiceB, 0.24m, 0),
                new Service(2, ServiceName.ServiceC, 0.4m, 1)
            }.ToList();
    }
}
