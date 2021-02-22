using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PricingService.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public ServiceName Name { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<ServiceCustomer> ServiceCustomers { get; set; }

        public Service() { }

        public Service(int id, ServiceName name, decimal price, int customerId)
        {
            Id = id;
            Name = name;
            Price = price;
            CustomerId = customerId;
        }
    }
    public enum ServiceName
    {
        ServiceA, ServiceB, ServiceC
    }
}
