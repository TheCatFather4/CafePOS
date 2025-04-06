namespace CafePOS.PL.IO
{
    public class Menus
    {
        public static int MainMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("| 4th Wall Cafe POS - Main Menu |");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Create an order");
            Console.WriteLine("2. Add an item to an order");
            Console.WriteLine("3. Process payment");
            Console.WriteLine("4. View open orders");
            Console.WriteLine("5. Cancel an order");
            Console.WriteLine("6. Daily sales report");
            Console.WriteLine("7. Quit\n");

            int choice;

            do
            {
                Console.Write("Enter choice (1-7): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 7)
                {
                    return choice;
                }

                Console.WriteLine("You must select an number from 1 to 7.");
            } while (true);
        }

        public static void PaymentHeader()
        {
            Console.Clear();
            Console.WriteLine("Payment Options");
            Console.WriteLine("===============================");
            Console.WriteLine($"{"ID", -5} Payment Type");
            Console.WriteLine("===============================");
        }

        public static void ItemHeader()
        {
            Console.Clear();
            Console.WriteLine("List of Items");
            Console.WriteLine("=======================================");
            Console.WriteLine($"{"ID",-5} {"Name",-20} Price");
            Console.WriteLine("=======================================");
        }

        public static void CategoryHeader()
        {
            Console.Clear();
            Console.WriteLine("List of Categories");
            Console.WriteLine("==================================");
            Console.WriteLine($"{"ID",-5} {"Name"}");
            Console.WriteLine("==================================");
        }

        public static void OpenOrderHeader()
        {
            Console.Clear();
            Console.WriteLine("Open Orders");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"{"Name",-26} {"Order ID",-15} Order Date");
            Console.WriteLine(new string('=', 60));
        }

        public static void OrderDetailsHeader(int orderID)
        {
            Console.Clear();
            Console.WriteLine($"Order details for Order {orderID}");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"{"Item Name",-20} {"Item Price",-16} Quantity");
            Console.WriteLine(new string('=', 60));
        }

        public static void TrainingHeader(string line)
        {
            for (int i = 1; i < 34; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(line[i - 1]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(line[i - 1]);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
    }
}