using PricingService.Data;
using PricingService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PricingService.Services
{
    public class PricingServiceService : IPricingService
    {
        public IRepository _repository { get; }

        public PricingServiceService(IRepository repository)
        {
            _repository = repository;
        }

        public decimal GetTotalPriceForCustomer(int customerId, DateTime start, DateTime end)
        {
            var customer = _repository.GetCustomerById(customerId).Result;
            var serviceList = _repository.GetServicesByCustomerId(customerId).Result;
            var discount = _repository.GetDiscountByCustomerId(customerId).Result;

            var (totalDaysWithDiscount, totalDaysWithoutDiscount) = GetPricesForDays(start, end, customer, discount);

            decimal totalPrice = GetTotalPrice(serviceList, discount, totalDaysWithDiscount, totalDaysWithoutDiscount);

            return totalPrice;
        }

        private (decimal, decimal) GetPricesForDays(DateTime start, DateTime end, Customer customer, Discount discount)
        {
            var totalFreeDays = customer?.NumberofFreeDays;
            var numberOfPayingDays = Convert.ToDecimal((end - start).TotalDays - totalFreeDays);
            var totalDaysWithDiscount = Convert.ToDecimal((discount.EndDate - discount.StartDate).TotalDays);
            var totalDaysWithoutDiscount = numberOfPayingDays - totalDaysWithDiscount;

            return (totalDaysWithDiscount, totalDaysWithoutDiscount);
        }

        private decimal GetTotalPrice(IEnumerable<Service> serviceList, Discount discount, decimal totalDaysWithDiscount, decimal totalDaysWithoutDiscount)
        {
            var totalPrice = 0m;
            foreach (var service in serviceList)
            {
                var serviceDiscount = discount.Percent;
                var priceForNotDiscountedDays = service.Price * totalDaysWithoutDiscount;
                var priceForDiscountedDays = (service.Price * serviceDiscount) * totalDaysWithDiscount;
                totalPrice = priceForDiscountedDays + priceForNotDiscountedDays;
            }

            return totalPrice;
        }
    }
}
