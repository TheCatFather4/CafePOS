using CafePOS.BLL.Services;
using CafePOS.Tests.MockData.SalesReportRepos;
using NUnit.Framework;

namespace CafePOS.Tests
{
    [TestFixture]
    public class SalesReportTests
    {
        [Test]
        public void Get_Orders_By_Date_Fail()
        {
            var service = new SalesReportService(new SalesReportUnavailable());

            var result = service.GetOrdersByDate("01/01/2025");

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void Get_Orders_By_Date_Succeed()
        {
            var service = new SalesReportService(new SalesReportAvailable());

            var result = service.GetOrdersByDate("01/01/2025");

            Assert.That(result.Ok, Is.True);
        }
    }
}