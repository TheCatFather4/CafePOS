using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.DL.Repositories
{
    public class EFNewOrderRepository : INewOrderRepository
    {
        private CafeContext _dbContext;

        public EFNewOrderRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);
        }

        public List<Server> GetAllServers()
        {
            return _dbContext.Server
                .Where(s => s.TermDate == null)
                .ToList();
        }

        public Server? GetServerID(int serverID)
        {
            return _dbContext.Server
                .FirstOrDefault(s => s.ServerID == serverID && s.TermDate == null);
        }

        public void CreateNewOrder(CafeOrder order)
        {
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }

        public int GetOrderID()
        {
            return _dbContext.CafeOrder
                .OrderByDescending(co => co.OrderID)
                .First().OrderID;
        }
    }
}