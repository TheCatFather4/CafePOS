using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafePOS.DL.Repositories
{
    public class EFOrderUpdateRepository : IOrderUpdateRepository
    {
        private CafeContext _dbContext;

        public EFOrderUpdateRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);
        }

        public List<CafeOrder> GetOpenOrders()
        {
            return _dbContext.CafeOrder
                .Include(co => co.Server)
                .Where(co => co.PaymentTypeID == 6)
                .ToList();
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return _dbContext.OrderItem
                .Include(oi => oi.ItemPrice.Item)
                .Where(oi => oi.OrderID == orderID)
                .ToList();
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Category.ToList();
        }

        public List<ItemPrice> GetItemsByCategory(int categoryID, int timeOfDay)
        {
            return _dbContext.ItemPrice
                .Include(ip => ip.Item)
                .Where(ip => ip.Item.CategoryID == categoryID && ip.TimeOfDayID == timeOfDay)
                .ToList();
        }

        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            foreach (var oi in orderItems)
            {
                var price = _dbContext.ItemPrice
                    .FirstOrDefault(ip => ip.ItemPriceID == oi.ItemPriceID).Price;

                OrderItem item = new OrderItem
                {
                    OrderID = oi.OrderID,
                    ItemPriceID = oi.ItemPriceID,
                    Quantity = (byte)oi.Quantity,
                    ExtendedPrice = price * oi.Quantity
                };
                _dbContext.OrderItem.Add(item);
            }

            _dbContext.SaveChanges();
        }

        public ItemPrice GetItemPrice(int itemID, int timeOfDay)
        {
            return _dbContext.ItemPrice
                .FirstOrDefault(ip => ip.ItemID == itemID && ip.TimeOfDayID == timeOfDay);
        }

        public void CancelOrder(int orderID)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.OrderItem
                    .Where(oi => oi.OrderID == orderID)
                    .ExecuteDelete();

                _dbContext.CafeOrder
                    .Where(co => co.OrderID == orderID)
                    .ExecuteDelete();

                transaction.Commit();
            }
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return _dbContext.PaymentType.ToList();
        }

        public void ProcessPayment(CafeOrder order)
        {
            _dbContext.CafeOrder.Update(order);
            _dbContext.SaveChanges();
        }

        public CafeOrder GetSubTotals(int orderID)
        {
            var order = _dbContext.CafeOrder
                .FirstOrDefault(co => co.OrderID == orderID && co.PaymentTypeID == 6);

            var orderItems = _dbContext.OrderItem
                .Include(oi => oi.ItemPrice)
                .Where(oi => oi.OrderID == orderID)
                .ToList();

            if (orderItems.Count > 0)
            {
                order.SubTotal = orderItems.Sum(oi => oi.ExtendedPrice);
                order.Tax = order.SubTotal * .088M;
                order.AmountDue = order.SubTotal + order.Tax;

                int quantity = 0;

                foreach (var oi in orderItems)
                {
                    quantity += oi.Quantity;
                }

                if (quantity > 15)
                {
                    order.Tip = order.AmountDue * .15M;
                    order.AmountDue += order.Tip;
                }
            }

            _dbContext.SaveChanges();

            return order;
        }
    }
}