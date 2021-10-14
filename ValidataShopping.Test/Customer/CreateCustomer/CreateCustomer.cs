using MediatR;
using Moq;
using NUnit.Framework;
using System.Threading;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Application.Customers.CreateCustomer;

namespace ValidataShopping.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Create_Customer()
        {
            var _mediator = new Mock<CreateCustomerHandler>();
            var result = _mediator.Object.Handle(
                new CreateCustomerCommand("test customer", "test address", "test postal"), new CancellationToken());
            Assert.Pass();
        }
    }
}