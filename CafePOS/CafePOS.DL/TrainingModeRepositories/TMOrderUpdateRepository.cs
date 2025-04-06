using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using System.Data;

namespace CafePOS.DL.TrainingModeRepositories
{
    public class TMOrderUpdateRepository : IOrderUpdateRepository
    {
        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            foreach (var i in orderItems)
            {
                var itemPrice = TrainingContext.ItemPrices.Where(ip => ip.ItemPriceID == i.ItemPriceID).First();

                OrderItem item = new OrderItem
                {
                    OrderID = i.OrderID,
                    ItemPriceID = i.ItemPriceID,
                    Quantity = (byte)i.Quantity,
                    ExtendedPrice = i.Quantity * itemPrice.Price
                };

                TrainingContext.OrderItems.Add(item);
            }
        }

        public void CancelOrder(int orderID)
        {
            var orderItems = TrainingContext.OrderItems.ToList();

            foreach (var oi in orderItems.ToList())
            {
                if (oi.OrderID == orderID)
                {
                    orderItems.Remove(oi);
                }
            }

            TrainingContext.OrderItems = orderItems;

            var cafeOrder = TrainingContext.CafeOrders
                .First(co => co.OrderID == orderID);

            TrainingContext.CafeOrders.Remove(cafeOrder);
        }

        public List<Category> GetCategories()
        {
            return TrainingContext.Categories
                .ToList();
        }

        public ItemPrice GetItemPrice(int itemID, int timeOfDay)
        {
            return TrainingContext.ItemPrices
                .Find(ip => ip.ItemID == itemID);
        }

        public List<ItemPrice> GetItemsByCategory(int categoryID, int timeOfDay)
        {
            var itemsByCategory = new List<ItemPrice>();

            var items = TrainingContext.Items
                .Where(i => i.CategoryID == categoryID)
                .ToList();

            var itemPrices = TrainingContext.ItemPrices;

            foreach (var ip in itemPrices)
            {
                foreach (var i in items)
                {
                    if (ip.ItemID == i.ItemID)
                    {
                        ip.Item = i;
                        itemsByCategory.Add(ip);
                    }
                }
            }

            return itemsByCategory;
        }

        public List<CafeOrder> GetOpenOrders()
        {
            var openOrders = TrainingContext.CafeOrders
                .Where(co => co.PaymentTypeID == 6).ToList();

            foreach (var order in openOrders)
            {
                Server server = TrainingContext.Servers
                    .First(s => s.ServerID == order.ServerID);

                order.Server = server;
            }

            return openOrders;
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            var orderItemList = new List<OrderItem>();

            var orderItems = TrainingContext.OrderItems
                .Where(oi => oi.OrderID == orderID)
                .ToList();

            var itemPrices = TrainingContext.ItemPrices
                .ToList();

            var items = TrainingContext.Items
                .ToList();

            foreach (var oi in orderItems)
            {
                foreach(var ip in itemPrices)
                {
                    if (ip.ItemPriceID == oi.ItemPriceID)
                    {
                        oi.ItemPrice = ip;
                        orderItemList.Add(oi);
                    }
                }
            }

            foreach (var oil in orderItemList)
            {
                foreach (var i in items)
                {
                    if (oil.ItemPrice.ItemID == i.ItemID)
                    {
                        oil.ItemPrice.Item = i;
                    }
                }
            }

            return orderItemList;
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return TrainingContext.PaymentTypes
                .Where(pt => pt.PaymentTypeID != 6)
                .ToList();
        }

        public CafeOrder GetSubTotals(int orderID)
        {
            var order = TrainingContext.CafeOrders
                .FirstOrDefault(co => co.OrderID == orderID && co.PaymentTypeID == 6);

            var orderItems = TrainingContext.OrderItems
                .Where(oi => oi.OrderID == orderID)
                .ToList();

            if (orderItems.Count() > 0)
            {
                order.SubTotal = orderItems.Sum(oi => oi.ExtendedPrice);
                order.Tax = order.SubTotal * 0.088M;
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

            return order;
        }

        public void ProcessPayment(CafeOrder order)
        {
            CafeOrder old = TrainingContext.CafeOrders.First(co =>  co.OrderID == order.OrderID);

            var index = TrainingContext.CafeOrders.IndexOf(old);

            TrainingContext.CafeOrders[index] = order;
        }
    }
}