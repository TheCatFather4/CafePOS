using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.PL.IO
{
    public class NewOrderWorkflows
    {
        public static void CreateNewOrder(INewOrderService service)
        {
            GetServers(service);

            int choice = GetServerID(service);

            if (choice == 0)
            {
                return;
            }

            var order = new CafeOrder()
            {
                ServerID = choice,
                OrderDate = DateTime.Now,
                PaymentTypeID = 6
            };

            service.CreateNewOrder(order);

            GetOrderID(service);

            Utilities.AnyKey();
        }

        private static void GetServers(INewOrderService service)
        {
            Console.Clear();
            Console.WriteLine("Server List");
            Console.WriteLine("=========================");
            Console.WriteLine($"{"Name",-10} {"",-10} ID");
            Console.WriteLine("=========================");

            var result = service.GetAllServers();

            if (result.Ok)
            {
                foreach (var s in result.Data)
                {
                    Console.WriteLine($"{s.FirstName,-10} {s.LastName,-10} {s.ServerID}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static int GetServerID(INewOrderService service)
        {
            int choice;

            do
            {
                choice = Utilities.GetID("\nChoose a Server by ID (0 to Quit): ");

                if (choice == 0)
                {
                    break;
                }

                var result = service.GetServerID(choice);

                if (result.Ok)
                {
                    return result.Data.ServerID;
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            } while (true);

            return choice;
        }

        private static void GetOrderID(INewOrderService service)
        {
            var result = service.GetOrderID();

            if (result.Ok)
            {
                Console.WriteLine($"New order created with an ID of {result.Data.ToString()}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}