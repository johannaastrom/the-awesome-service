using System;
using System.ComponentModel.DataAnnotations;

namespace TheAwesomeService.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public decimal Percent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Discount(int id, decimal percent, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Percent = percent;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
