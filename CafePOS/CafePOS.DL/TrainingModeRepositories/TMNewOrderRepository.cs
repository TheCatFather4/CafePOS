using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.DL.TrainingModeRepositories
{
    public class TMNewOrderRepository : INewOrderRepository
    {
        public void CreateNewOrder(CafeOrder order)
        {
            order.OrderID = TrainingContext.CafeOrders
                .Last().OrderID + 1;

            TrainingContext.CafeOrders.Add(order);
        }

        public List<Server> GetAllServers()
        {
            return TrainingContext.Servers
                .Where(s => s.TermDate == null)
                .ToList();
        }

        public int GetOrderID()
        {
            return TrainingContext.CafeOrders
                .OrderByDescending(co => co.OrderID)
                .First().OrderID;
        }

        public Server? GetServerID(int serverID)
        {
            return TrainingContext.Servers
                .FirstOrDefault(s => s.ServerID == serverID && 
                                     s.TermDate == null);
        }
    }
}