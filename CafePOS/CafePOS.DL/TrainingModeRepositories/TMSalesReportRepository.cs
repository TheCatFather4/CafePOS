using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.DL.TrainingModeRepositories
{
    public class TMSalesReportRepository : ISalesReportRepository
    {
        public List<OrderItem> GetOrdersByDate(string date)
        {
            var salesReport = new List<OrderItem>();

            var cafeOrders = TrainingContext.CafeOrders
                .Where(co => co.PaymentTypeID != 6 && 
                             co.OrderDate.ToShortDateString() == date);

            foreach (var order in cafeOrders)
            {
                var orderItems = TrainingContext.OrderItems
                    .Where(oi => oi.OrderID == order.OrderID)
                    .ToList();

                foreach (var oi in orderItems)
                {
                    oi.CafeOrder = order;
                    salesReport.Add(oi);
                }
            }

            foreach (var orderItem in salesReport)
            {
                ItemPrice price = TrainingContext.ItemPrices
                    .First(ip => ip.ItemPriceID == orderItem.ItemPriceID);

                orderItem.ItemPrice = price;

                Item name = TrainingContext.Items
                    .First(i => i.ItemID == orderItem.ItemPrice.ItemID);

                orderItem.ItemPrice.Item = name;
            }

            return salesReport;
        }
    }
}