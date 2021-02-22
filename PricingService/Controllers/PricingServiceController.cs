using Microsoft.AspNetCore.Mvc;
using PricingService.Models;
using PricingService.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PricingService.Controllers
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
            // todo ändra parametrar till variabler
            var totalPrice = pricingService.GetTotalPriceForCustomer(1, new DateTime(2020, 01, 01), new DateTime(2021, 01, 01));

            if (totalPrice == 0)
                return StatusCode((int)HttpStatusCode.BadRequest, "Customer does not exist.");

            return totalPrice;
        }
    }
}
