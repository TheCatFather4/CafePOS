using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.BLL.Services
{
    public class SalesReportService : ISalesReportService
    {
        private ISalesReportRepository _salesReportRepository;

        public SalesReportService(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository;
        }

        public Result<List<OrderItem>> GetOrdersByDate(string date)
        {
            try
            {
                var orders = _salesReportRepository.GetOrdersByDate(date);
                return ResultFactory.Success(orders);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<OrderItem>>(ex.Message);
            }
        }
    }
}