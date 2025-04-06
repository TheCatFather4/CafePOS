using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockData.NewOrderRepos
{
    public class NewOrderUnavailable : INewOrderRepository
    {
        public void CreateNewOrder(CafeOrder order)
        {
            throw new NotImplementedException();
        }

        public List<Server> GetAllServers()
        {
            throw new NotImplementedException();
        }

        public int GetOrderID()
        {
            throw new NotImplementedException();
        }

        public Server? GetServerID(int serverID)
        {
            throw new NotImplementedException();
        }
    }
}