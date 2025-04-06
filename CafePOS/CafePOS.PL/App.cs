using CafePOS.BLL;
using CafePOS.Core.Enums;
using CafePOS.Core.Interfaces.Application;
using CafePOS.PL.IO;

namespace CafePOS.PL
{
    public class App
    {
        private IAppConfiguration _config;
        private ServiceFactory _serviceFactory;

        public App(IAppConfiguration config)
        {
            _config = config;
            _serviceFactory = new ServiceFactory(config);
        }

        public void Run()
        {
            do
            {
                Console.Clear();

                if (_config.GetTrainingMode() == TrainingMode.Activated)
                {
                    Menus.TrainingHeader(new string('-', 33));
                    Menus.TrainingHeader("----------Training Mode----------");
                    Menus.TrainingHeader(new string('-', 33));
                }

                int choice = Menus.MainMenu();

                switch (choice)
                {
                    case 1:
                        NewOrderWorkflows.CreateNewOrder(_serviceFactory.CreateNewOrderService());
                        break;
                    case 2:
                        OrderUpdateWorkflows.AddItemsToOrder(_serviceFactory.CreateOrderUpdateService());
                        break;
                    case 3:
                        OrderUpdateWorkflows.ProcessPayment(_serviceFactory.CreateOrderUpdateService());
                        break;
                    case 4:
                        OrderUpdateWorkflows.ViewOpenOrders(_serviceFactory.CreateOrderUpdateService());
                        break;
                    case 5:
                        OrderUpdateWorkflows.CancelOrder(_serviceFactory.CreateOrderUpdateService());
                        break;
                    case 6:
                        SalesReportWorkflows.SalesReport(_serviceFactory.CreateSalesReportService());
                        break;
                    case 7:
                        return;
                }
            } while (true);
        }
    }
}