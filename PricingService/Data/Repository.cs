using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheAwesomeService.Models;

namespace TheAwesomeService.Data
{
    public class Repository : IRepository
    {
        // TODO context

        public async Task<Customer> GetCustomer(int customerId) =>
            new Customer(customerId, 10, new DateTime(2019, 09, 20), new DateTime(2019, 10, 01), CreateServiceList(), 0);

        private List<Service> CreateServiceList() =>
            new List<Service>()
            {
                new Service(1, ServiceName.ServiceA, 0.2m, new Discount(0,0,new DateTime(),new DateTime())),
                new Service(2, ServiceName.ServiceB, 0.24m, new Discount(0,0,new DateTime(),new DateTime())),
                new Service(3, ServiceName.ServiceC, 0.4m, new Discount(0,0,new DateTime(),new DateTime()))
            }.ToList();
    }
}
