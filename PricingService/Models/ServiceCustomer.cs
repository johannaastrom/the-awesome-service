namespace PricingService.Models
{
    public class ServiceCustomer
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
