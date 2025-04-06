using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafePOS.DL.Repositories
{
    public class EFSalesReportRepository : ISalesReportRepository
    {
        private CafeContext _dbContext;

        public EFSalesReportRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);        
        }

        public List<OrderItem> GetOrdersByDate(string date)
        {
            var orders = _dbContext.OrderItem
                .Include(oi => oi.CafeOrder)
                .Include(oi => oi.CafeOrder)
                .Include(oi => oi.ItemPrice)
                .Include(oi => oi.ItemPrice.Item)
                .Where(oi => oi.CafeOrder.PaymentTypeID != 6)
                .ToList();

            List<OrderItem> ordersByDate = new List<OrderItem>();

            foreach (var order in orders)
            {
                if (order.CafeOrder.OrderDate.ToShortDateString() == date)
                {
                    ordersByDate.Add(order);
                }
            }

            return ordersByDate;
        }
    }
}