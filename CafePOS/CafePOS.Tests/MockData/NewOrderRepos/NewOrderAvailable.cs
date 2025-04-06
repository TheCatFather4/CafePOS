using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockData.NewOrderRepos
{
    public class NewOrderAvailable : INewOrderRepository
    {
        public void CreateNewOrder(CafeOrder order)
        {
            throw new NotImplementedException();
        }

        public List<Server> GetAllServers()
        {
            return new List<Server>();
        }

        public int GetOrderID()
        {
            return 1;
        }

        public Server? GetServerID(int serverID)
        {
            return new Server();
        }
    }
}