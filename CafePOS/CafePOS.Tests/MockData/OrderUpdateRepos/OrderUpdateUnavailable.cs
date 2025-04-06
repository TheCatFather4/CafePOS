using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockData.OrderUpdateRepos
{
    public class OrderUpdateUnavailable : IOrderUpdateRepository
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
            throw new NotImplementedException();
        }

        public ItemPrice GetItemPrice(int itemID, int timeOfDay)
        {
            throw new NotImplementedException();
        }

        public List<ItemPrice> GetItemsByCategory(int categoryID, int timeOfDay)
        {
            throw new NotImplementedException();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<PaymentType> GetPaymentTypes()
        {
            throw new NotImplementedException();
        }

        public CafeOrder GetSubTotals(int orderID)
        {
            throw new NotImplementedException();
        }

        public void ProcessPayment(CafeOrder order)
        {
            throw new NotImplementedException();
        }
    }
}