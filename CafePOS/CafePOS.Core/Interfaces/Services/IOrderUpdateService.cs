using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Services
{
    public interface IOrderUpdateService
    {
        Result<List<CafeOrder>> GetOpenOrders();
        Result<List<OrderItem>> GetOrderItems(int orderID);
        Result<List<Category>> GetCategories();
        Result<List<ItemPrice>> GetItemsByCategory(int categoryID);
        Result<List<PaymentType>> GetPaymentTypes();
        Result AddItemsToOrder(List<ItemToAdd> orderItems);
        Result CancelOrder(int orderID);
        Result ProcessPayment(CafeOrder order);
        Result<CafeOrder> GetSubTotals(int orderID);
        Result<ItemPrice> GetItemPrice(int itemID);
    }
}