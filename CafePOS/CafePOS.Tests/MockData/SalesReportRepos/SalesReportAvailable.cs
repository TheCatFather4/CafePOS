using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockData.SalesReportRepos
{
    public class SalesReportAvailable : ISalesReportRepository
    {
        public List<OrderItem> GetOrdersByDate(string date)
        {
            return new List<OrderItem>();
        }
    }
}