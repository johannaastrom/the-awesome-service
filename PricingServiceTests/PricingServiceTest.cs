using System;
using NSubstitute;
using PricingService.Services;
using FluentAssertions;
using Xunit;
using PricingService.Models;
using System.Collections.Generic;

namespace PricingServiceTests
{
    public class PricingServiceTest
    {
        [Fact]
        public void Test_CustomerX() // TODO Döp om
        {
            var startDate = new DateTime(2019, 09, 20);
            var endDate = new DateTime(2019, 10, 01);
            var customer = new Customer(1, 5, startDate, endDate);

            var serviceList = new List<Service>() { new Service(1, ServiceName.ServiceA, 0.2m, customer.Id), new Service(2, ServiceName.ServiceC, 0.4m, customer.Id) };
            var sut = CreateSut();

            var actual = sut.GetTotalPriceForCustomer(1, startDate, endDate);

            var expexted = 100.0m;
            expexted.Should().Be(actual);
        }

        // Test för CustomerY

        private IPricingService CreateSut() => Substitute.For<IPricingService>();
    }
}
