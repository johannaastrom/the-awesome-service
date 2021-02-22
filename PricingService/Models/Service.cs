using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheAwesomeService.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public ServiceName Name { get; set; }
        public decimal BasePrice { get; set; }
        public Discount ServiceDiscount {get; set;}

        public Service(int id, ServiceName name, decimal basePrice, Discount serviceDiscount)
        {
            Id = id;
            Name = name;
            BasePrice = basePrice;
            ServiceDiscount = serviceDiscount;
        }
    }

    public enum ServiceName
    {
        ServiceA, ServiceB, ServiceC
    }
}
