using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockData.OrderUpdateRepos
{
    public class OrderUpdateAvailable : IOrderUpdateRepository
    {
        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            throw new NotImplementedException();
        }

        public void CancelOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            return new List<Category>();
        }

        public ItemPrice GetItemPrice(int itemID, int timeOfDay)
        {
            return new ItemPrice();
        }

        public List<ItemPrice> GetItemsByCategory(int categoryID, int timeOfDay)
        {
            return new List<ItemPrice>();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            return new List<CafeOrder>();
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return new List<OrderItem>();
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return new List<PaymentType>();
        }

        public CafeOrder GetSubTotals(int orderID)
        {
            return new CafeOrder();
        }

        public void ProcessPayment(CafeOrder order)
        {
            throw new NotImplementedException();
        }
    }
}