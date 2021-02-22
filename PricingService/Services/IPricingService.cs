using System;
using System.Threading.Tasks;

namespace TheAwesomeService.Services
{
    public interface IPricingService
    {
        Task<decimal> GetPriceForCustomer(int customerId, DateTime start, DateTime end);
    }
}
