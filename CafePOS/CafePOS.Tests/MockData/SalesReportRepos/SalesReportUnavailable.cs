using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockData.SalesReportRepos
{
    public class SalesReportUnavailable : ISalesReportRepository
    {
        public List<OrderItem> GetOrdersByDate(string date)
        {
            throw new NotImplementedException();
        }
    }
}