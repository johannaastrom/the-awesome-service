using System;

namespace PricingService.Services
{
    public interface IPricingService
    {
        decimal GetTotalPriceForCustomer(int customerId, DateTime start, DateTime end);
    }
}
