using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Repositories
{
    public interface INewOrderRepository
    {
        List<Server> GetAllServers();
        Server? GetServerID(int serverID);
        void CreateNewOrder(CafeOrder order);
        int GetOrderID();
    }
}