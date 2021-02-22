using TheAwesomeService.Data;
using System;
using System.Threading.Tasks;
using TheAwesomeService.Models;

namespace TheAwesomeService.Services
{
    public class PricingService : IPricingService
    {
        public IRepository repository { get; }

        public PricingService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<decimal> GetPriceForCustomer(int customerId, DateTime start, DateTime end)
        {
            var customer = await repository.GetCustomer(customerId);
            var totalPayingDays = Convert.ToDecimal((end - start).TotalDays - customer.NumberOfFreeDays);
            
            return GetTotalPrice(customer, totalPayingDays);
        }

        private decimal GetTotalPrice(Customer customer, decimal totalPayingDays)
        {
            var totalPrice = 0m;
            foreach (var service in customer.ServiceList)
            {
                if (customer.FixedDiscount > 0)
                {
                    totalPrice += Convert.ToDecimal((1 - customer.FixedDiscount) * service.BasePrice * totalPayingDays);
                    continue;
                }

                var (priceForNotDiscountedDays, priceForDiscountedDays) = GetPriceForService(totalPayingDays, service);
                totalPrice += (priceForNotDiscountedDays + priceForDiscountedDays);
            }

            return totalPrice;
        }

        private (decimal, decimal) GetPriceForService(decimal totalPayingDays, Service service)
        {
            var totalDaysWithDiscount = Convert.ToDecimal((service.ServiceDiscount.EndDate - service.ServiceDiscount.StartDate).TotalDays);
            var totalDaysWithoutDiscount = totalPayingDays - totalDaysWithDiscount;
            var priceForNotDiscountedDays = totalDaysWithoutDiscount * service.BasePrice;
            var priceForDiscountedDays = (1 - service.ServiceDiscount.Percent) * service.BasePrice * totalDaysWithDiscount;

            return (priceForNotDiscountedDays, priceForDiscountedDays);
        }
    }
}
