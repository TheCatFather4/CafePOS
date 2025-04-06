using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Services
{
    public interface ISalesReportService
    {
        Result<List<OrderItem>> GetOrdersByDate(string date);
    }
}