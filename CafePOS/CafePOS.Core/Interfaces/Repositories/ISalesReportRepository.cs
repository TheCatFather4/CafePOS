using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Repositories
{
    public interface ISalesReportRepository
    {
        List<OrderItem> GetOrdersByDate(string date);
    }
}