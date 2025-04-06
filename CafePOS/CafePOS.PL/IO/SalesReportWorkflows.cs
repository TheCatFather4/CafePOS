using CafePOS.Core.Interfaces.Services;

namespace CafePOS.PL.IO
{
    public class SalesReportWorkflows
    {
        public static void SalesReport(ISalesReportService service)
        {
            Console.Clear();

            string date = Utilities.GetDate().ToShortDateString(); 
            
            var result = service.GetOrdersByDate(date);

            if (result.Ok)
            {
                if (result.Data.Count() > 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Daily Sales Report (Items) for {date}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(new string('=', 95));
                    Console.ResetColor();
                    Console.WriteLine($"{"Time of Day", -15} {"ID", -10} {"Item Name", -30} {"Quantity", -10} {"Price", -10} Extended Price");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(new string('=', 95));
                    Console.ResetColor();
                    decimal total = 0;
                    foreach (var oi in result.Data)
                    {
                        total += oi.ExtendedPrice;
                        Console.WriteLine($"{oi.CafeOrder.OrderDate.ToShortTimeString(), -15} {oi.OrderID, -10} {oi.ItemPrice.Item.ItemName, -30} {oi.Quantity, -10} {oi.ItemPrice.Price, -10} {oi.ExtendedPrice}");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(new string('-', 95));
                        Console.ResetColor();
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(new string('=', 95));
                    Console.ResetColor();
                    Console.Write($"Total Sales: ");
                    Utilities.DisplayTotalGreen(total);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(new string('=', 95));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"No orders are available for {date}.");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Utilities.AnyKey();
        }
    }
}