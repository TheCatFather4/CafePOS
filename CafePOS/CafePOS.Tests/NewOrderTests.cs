using CafePOS.BLL.Services;
using CafePOS.Tests.MockData.NewOrderRepos;
using NUnit.Framework;

namespace CafePOS.Tests
{
    [TestFixture]
    public class NewOrderTests
    {
        [Test]
        public void Get_Servers_Fail()
        {
            var service = new NewOrderService(new NewOrderUnavailable());

            var result = service.GetAllServers();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Servers_Succeed()
        {
            var service = new NewOrderService(new NewOrderAvailable());

            var result = service.GetAllServers();

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_OrderID_Fail()
        {
            var service = new NewOrderService(new NewOrderUnavailable());

            var result = service.GetOrderID();

            Assert.That (result.Ok, Is.False);
        }

        [Test]
        public void Get_OrderID_Succeed()
        {
            var service = new NewOrderService(new NewOrderAvailable());

            var result = service.GetOrderID();

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_ServerID_Fail()
        {
            var service = new NewOrderService(new NewOrderUnavailable());

            var result = service.GetServerID(1);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_ServerID_Succeed()
        {
            var service = new NewOrderService(new NewOrderAvailable());

            var result = service.GetServerID(1);

            Assert.That(result.Ok, Is.True);
        }
    }
}