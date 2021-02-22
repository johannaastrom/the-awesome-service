using System;
using System.ComponentModel.DataAnnotations;

namespace PricingService.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public decimal Percent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Discount() { }

        public Discount(int id, decimal percent, DateTime startDate, DateTime endDate, int customerId)
        {
            Id = id;
            Percent = percent;
            StartDate = startDate;
            EndDate = endDate;
            CustomerId = customerId;
        }
    }
}
