using System;
using NSubstitute;
using FluentAssertions;
using Xunit;
using TheAwesomeService.Models;
using System.Collections.Generic;
using TheAwesomeService.Data;
using TheAwesomeService.Services;

namespace PricingServiceTests
{
    public class PricingServiceTest
    {
        [Fact]
        public void Test_CustomerX()
        {
            var (sut, repository) = CreateSut();
            var serviceList = new List<Service>() { 
                new Service(1, ServiceName.ServiceA, 0.2m, new Discount(1, 0, new DateTime(), new DateTime())), 
                new Service(2, ServiceName.ServiceC, 0.4m, new Discount(1, 0.2m, new DateTime(2019, 09, 22), new DateTime(2019, 09, 24))) 
            };
            var customer = new Customer(1, 0, new DateTime(2019, 09, 20), new DateTime(2019, 10, 01), serviceList, 0);
            repository.GetCustomer(default).ReturnsForAnyArgs(customer);

            var actual = sut.GetPriceForCustomer(1, customer.StartDate, customer.EndDate);

            var expected = 6.44m;
            expected.Should().Be(actual.Result);
        }

        [Fact]
        public void Test_CustomerY()
        {
            var (sut, repository) = CreateSut();
            var serviceList = new List<Service>() {
                new Service(1, ServiceName.ServiceB, 0.24m, new Discount(1, 0, new DateTime(), new DateTime())),
                new Service(2, ServiceName.ServiceC, 0.4m, new Discount(1, 0, new DateTime(), new DateTime()))
            };
            var customer = new Customer(1, 200, new DateTime(2018, 01, 01), new DateTime(2019, 10, 01), serviceList, 0.3m);
            repository.GetCustomer(default).ReturnsForAnyArgs(customer);

            var actual = sut.GetPriceForCustomer(1, customer.StartDate, customer.EndDate);

            var expected = 196.224m;
            expected.Should().Be(actual.Result);
        }

        private (PricingService, IRepository) CreateSut()
        {
            var repository = Substitute.For<IRepository>();
            return (new PricingService(repository), repository);
        }
    }
}
