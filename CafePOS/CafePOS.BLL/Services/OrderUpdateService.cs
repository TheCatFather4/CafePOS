using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Application;
using CafePOS.Core.Interfaces.Repositories;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.BLL.Services
{
    public class OrderUpdateService : IOrderUpdateService
    {
        private IOrderUpdateRepository _orderUpdateRepository;
        private int _timeOfDay;

        public OrderUpdateService(IOrderUpdateRepository orderUpdateRepository, ITimeOfDaySetting timeOfDay)
        {
            _orderUpdateRepository = orderUpdateRepository;
            _timeOfDay = timeOfDay.GetTimeOfDaySetting();
        }

        public Result AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            try
            {
                _orderUpdateRepository.AddItemsToOrder(orderItems);
                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result CancelOrder(int orderID)
        {
            try
            {
                _orderUpdateRepository.CancelOrder(orderID);

                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result ProcessPayment(CafeOrder order)
        {
            try
            {
                _orderUpdateRepository.ProcessPayment(order);
                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result<List<Category>> GetCategories()
        {
            try
            {
                var categories = _orderUpdateRepository.GetCategories();
                return ResultFactory.Success(categories);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<Category>>(ex.Message);
            }
        }

        public Result<ItemPrice> GetItemPrice(int itemID)
        {
            try
            {
                var itemPrice = _orderUpdateRepository.GetItemPrice(itemID, _timeOfDay);
                return ResultFactory.Success(itemPrice);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<ItemPrice>(ex.Message);
            }
        }

        public Result<List<ItemPrice>> GetItemsByCategory(int categoryID)
        {
            try
            {
                var items = _orderUpdateRepository.GetItemsByCategory(categoryID, _timeOfDay);
                return ResultFactory.Success(items);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<ItemPrice>>(ex.Message);
            }
        }

        public Result<List<CafeOrder>> GetOpenOrders()
        {
            try
            {
                var orders = _orderUpdateRepository.GetOpenOrders();
                return ResultFactory.Success(orders);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<CafeOrder>>(ex.Message);
            }
        }

        public Result<List<OrderItem>> GetOrderItems(int orderID)
        {
            try
            {
                var items = _orderUpdateRepository.GetOrderItems(orderID);
                return ResultFactory.Success(items);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<OrderItem>>(ex.Message);
            }
        }

        public Result<List<PaymentType>> GetPaymentTypes()
        {
            try
            {
                var payTypes = _orderUpdateRepository.GetPaymentTypes();
                return ResultFactory.Success(payTypes);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<PaymentType>>(ex.Message);
            }
        }

        public Result<CafeOrder> GetSubTotals(int orderID)
        {
            try
            {
                var order = _orderUpdateRepository.GetSubTotals(orderID);
                return ResultFactory.Success(order);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<CafeOrder>(ex.Message);
            }
        }
    }
}