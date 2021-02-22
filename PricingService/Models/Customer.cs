using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PricingService.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int NumberofFreeDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<ServiceCustomer> ServiceCustomers { get; set; }

        public List<Discount> Discounts { get; set; }

        public Customer() { }

        public Customer(int id, int numberofFreeDays, DateTime startDate, DateTime endDate)
        {
            Id = id;
            NumberofFreeDays = numberofFreeDays;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
