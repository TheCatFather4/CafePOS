using CafePOS.BLL.Services;
using CafePOS.Core.TimeOfDaySettings;
using CafePOS.Tests.MockData.OrderUpdateRepos;
using NUnit.Framework;

namespace CafePOS.Tests
{
    [TestFixture]
    public class OrderUpdateTests
    {
        [Test]
        public void Get_Categories_Fail()
        {
            var service = new OrderUpdateService(new OrderUpdateUnavailable(), new Dinner());

            var result = service.GetCategories();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Categories_Success()
        {
            var service = new OrderUpdateService(new OrderUpdateAvailable(), new Dinner());

            var result = service.GetCategories();

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_ItemPrice_Fail()
        {
            var service = new OrderUpdateService(new OrderUpdateUnavailable(), new Dinner());

            var result = service.GetItemPrice(1);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_ItemPrice_Success()
        {
            var service = new OrderUpdateService(new OrderUpdateAvailable(), new Dinner());

            var result = service.GetItemPrice(1);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_Items_By_Category_Fail()
        {
            var service = new OrderUpdateService(new OrderUpdateUnavailable(), new Dinner());

            var result = service.GetItemsByCategory(1);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Items_By_Category_Succeed()
        {
            var service = new OrderUpdateService(new OrderUpdateAvailable(), new Dinner());

            var result = service.GetItemsByCategory(1);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_Open_Orders_Fail()
        {
            var service = new OrderUpdateService(new OrderUpdateUnavailable(), new Dinner());

            var result = service.GetOpenOrders();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Open_Orders_Success()
        {
            var service = new OrderUpdateService(new OrderUpdateAvailable(), new Dinner());

            var result = service.GetOpenOrders();

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_Order_Items_Fail()
        {
            var service = new OrderUpdateService(new OrderUpdateUnavailable(), new Dinner());

            var result = service.GetOrderItems(1);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Order_Items_Success()
        {
            var service = new OrderUpdateService(new OrderUpdateAvailable(), new Dinner());

            var result = service.GetOrderItems(1);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_Payment_Types_Fail()
        {
            var service = new OrderUpdateService(new OrderUpdateUnavailable(), new Dinner());

            var result = service.GetPaymentTypes();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Payment_Types_Succeed()
        {
            var service = new OrderUpdateService(new OrderUpdateAvailable(), new Dinner());

            var result = service.GetPaymentTypes();

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void Get_Subtotals_Fail()
        {
            var service = new OrderUpdateService(new OrderUpdateUnavailable(), new Dinner());

            var result = service.GetSubTotals(1);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Subtotals_Succeed()
        {
            var service = new OrderUpdateService(new OrderUpdateAvailable(), new Dinner());

            var result = service.GetSubTotals(1);

            Assert.That(result.Ok, Is.True);
        }
    }
}