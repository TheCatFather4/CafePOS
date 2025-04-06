using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Repositories
{
    public interface IOrderUpdateRepository
    {
        List<CafeOrder> GetOpenOrders();
        List<OrderItem> GetOrderItems(int orderID);
        List<Category> GetCategories();
        List<ItemPrice> GetItemsByCategory(int categoryID, int timeOfDay);
        List<PaymentType> GetPaymentTypes();
        void AddItemsToOrder(List<ItemToAdd> orderItems);
        void CancelOrder(int orderID);
        void ProcessPayment(CafeOrder order);
        CafeOrder GetSubTotals(int orderID);
        ItemPrice GetItemPrice(int itemID, int timeOfDay);
    }
}