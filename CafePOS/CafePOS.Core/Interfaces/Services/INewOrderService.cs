using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Services
{
    public interface INewOrderService
    {
        Result<List<Server>> GetAllServers();
        Result<Server> GetServerID(int serverID);
        void CreateNewOrder(CafeOrder newOrder);
        Result<int> GetOrderID();
    }
}