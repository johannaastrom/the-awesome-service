using PricingService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricingService.Data
{
    public interface IRepository
    {
        Task<Customer> GetCustomerById(int customerId);
        Task<Discount> GetDiscountByCustomerId(int customerId);
        Task<IEnumerable<Service>> GetServicesByCustomerId(int customerId);
    }
}
