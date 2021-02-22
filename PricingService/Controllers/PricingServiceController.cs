using Microsoft.AspNetCore.Mvc;
using TheAwesomeService.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TheAwesomeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingServiceController : ControllerBase
    {
        public readonly IPricingService pricingService;

        public PricingServiceController(IPricingService pricingService)
        {
            this.pricingService = pricingService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(double), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<decimal>> GetPrice(int customerId, DateTime start, DateTime end)
        {
            if (customerId == 0)
                return StatusCode((int)HttpStatusCode.BadRequest, "Customer does not exist.");

            return await pricingService.GetPriceForCustomer(customerId, start, end);
        }
    }
}
