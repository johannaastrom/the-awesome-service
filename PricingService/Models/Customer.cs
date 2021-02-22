using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheAwesomeService.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfFreeDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Service> ServiceList { get; set; }
        public decimal? FixedDiscount { get; set; }

        public Customer(int id, int numberOfFreeDays, DateTime startDate, DateTime endDate, List<Service> serviceList, decimal? fixedDiscount)
        {
            Id = id;
            NumberOfFreeDays = numberOfFreeDays;
            StartDate = startDate;
            EndDate = endDate;
            ServiceList = serviceList;
            FixedDiscount = fixedDiscount;
        }
    }
}
