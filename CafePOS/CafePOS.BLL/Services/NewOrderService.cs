using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.BLL.Services
{
    public class NewOrderService : INewOrderService
    {
        private INewOrderRepository _newOrderRepository;

        public NewOrderService(INewOrderRepository newOrderRepository)
        {
            _newOrderRepository = newOrderRepository;
        }

        public Result<List<Server>> GetAllServers()
        {
            try
            {
                var servers = _newOrderRepository.GetAllServers();
                return ResultFactory.Success(servers);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<Server>>(ex.Message);
            }
        }

        public Result<Server> GetServerID(int serverID)
        {
            try
            {
                var server = _newOrderRepository.GetServerID(serverID);

                return server is null ?
                    ResultFactory.Fail<Server>($"Server with ID: {serverID} not found!") :
                    ResultFactory.Success(server);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<Server>(ex.Message);
            }
        }

        public void CreateNewOrder(CafeOrder newOrder)
        {
            _newOrderRepository.CreateNewOrder(newOrder);
        }

        public Result<int> GetOrderID()
        {
            try
            {
                int orderID = _newOrderRepository.GetOrderID();
                return ResultFactory.Success(orderID);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<int>(ex.Message);
            }
        }
    }
}