namespace CafePOS.PL.IO
{
    public class Utilities
    {
        public static void AnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static int GetID(string prompt)
        {
            int choice;

            do
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice > -1)
                    {
                        return choice;
                    }
                }

                Console.WriteLine("Invalid choice!");
            } while (true);
        }

        public static bool AddMoreItems(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().ToUpper();

                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (true);
        }

        public static DateTime GetDate()
        {
            DateTime date = new DateTime();

            do
            {
                Console.Write("Enter date (MM/DD/YYYY): ");

                if (DateTime.TryParse(Console.ReadLine(), out date) && date <= DateTime.Today)
                {
                    return date;
                }

                Console.WriteLine("Invalid input!");
            }
            while (true);
        }

        public static void DisplayTotalGreen(decimal total)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"${total}");
            Console.ResetColor();
        }

        public static decimal GetTipAmount()
        {
            decimal tip;

            do
            {
                Console.Write("How much would you like to tip? ");
                if (decimal.TryParse(Console.ReadLine(), out tip))
                {
                    if (tip > 0)
                    {
                        return tip;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid tip amount!");
                }
            }
            while (true);
        }
    }
}