using CafePOS.Core.DTOs;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.PL.IO
{
    public class OrderUpdateWorkflows
    {
        public static void ViewOpenOrders(IOrderUpdateService service)
        {
            int choice = ViewOrdersAndGetOrderID(service);

            if (choice == 0)
            {
                return;
            }

            var result = service.GetOrderItems(choice);

            if (result.Ok)
            {
                if (result.Data.Count() > 0)
                {
                    Menus.OrderDetailsHeader(choice);

                    foreach (var oi in result.Data)
                    {
                        Console.WriteLine($"{oi.ItemPrice.Item.ItemName,-20} {oi.ItemPrice.Price,-16} {oi.Quantity}");
                    }
                }
                else
                {
                    Console.WriteLine($"There are no order items for order {choice}!");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Utilities.AnyKey();
        }

        public static void AddItemsToOrder(IOrderUpdateService service)
        {
            List<ItemToAdd> itemsAdded = new List<ItemToAdd>();

            int orderID = ViewOrdersAndGetOrderID(service);

            if (orderID == 0)
            {
                return;
            }

            do
            {
                int categoryID = GetCategoriesAndID(service);

                if (categoryID == 0)
                {
                    return;
                }

                ItemToAdd item = new ItemToAdd();

                int itemID = GetItemsAndID(service, categoryID);

                if (itemID == 0)
                {
                    return;
                }

                int quantity = Utilities.GetID("Enter quantity (0 to quit): ");

                if (quantity == 0)
                {
                    return;
                }

                var result = service.GetItemPrice(itemID);

                if (result.Ok)
                {
                    item.OrderID = orderID;
                    item.ItemPriceID = result.Data.ItemPriceID;
                    item.Quantity = quantity;

                    itemsAdded.Add(item);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }

            } while (Utilities.AddMoreItems("Would you like to add more items to the order? (y/n): "));
         
            var addItemResult = service.AddItemsToOrder(itemsAdded);

            if (addItemResult.Ok)
            {
                Console.WriteLine("Items successfully added!");
            }
            else
            {
                Console.WriteLine(addItemResult.Message);
            }

            Utilities.AnyKey();
        }

        public static void CancelOrder(IOrderUpdateService service)
        {
            int choice = ViewOrdersAndGetOrderID(service);

            if (choice == 0)
            {
                return;
            }

            var result = service.CancelOrder(choice);

            if (result.Ok)
            {
                Console.WriteLine($"Order {choice} successfully canceled.");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Utilities.AnyKey();
        }

        public static int ViewOrdersAndGetOrderID(IOrderUpdateService service)
        {
            Menus.OpenOrderHeader();

            var result = service.GetOpenOrders();

            List<int> orderIDs = new List<int>();

            if (result.Ok)
            {
                foreach (var o in result.Data)
                {
                    orderIDs.Add(o.OrderID);
                    Console.WriteLine($"{o.Server.FirstName,-10} {o.Server.LastName,-15} {o.OrderID,-15} {o.OrderDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            do
            {
                int choice = Utilities.GetID("\nChoose an order by ID (0 to quit): ");

                if (orderIDs.Contains(choice) || choice == 0)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Not a valid choice!");
                }
            } while (true);
        }

        public static int GetCategoriesAndID(IOrderUpdateService service)
        {
            Menus.CategoryHeader();

            var result = service.GetCategories();

            List<int> categoryIDs = new List<int>();

            if (result.Ok)
            {
                foreach (var c in result.Data)
                {
                    categoryIDs.Add(c.CategoryID);
                    Console.WriteLine($"{c.CategoryID,-5} {c.CategoryName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            do
            {
                int choice = Utilities.GetID("\nChoose a category by ID (0 to quit): ");

                if (categoryIDs.Contains(choice) || choice == 0)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Not a valid choice!");
                }
            } while (true);
        }
        
        public static int GetItemsAndID(IOrderUpdateService service, int categoryID)
        {
            Menus.ItemHeader();

            var result = service.GetItemsByCategory(categoryID);

            List<int> itemIDs = new List<int>();

            if (result.Ok)
            {
                foreach (var ip in result.Data)
                {
                    itemIDs.Add(ip.ItemID);
                    Console.WriteLine($"{ip.ItemID,-5} {ip.Item.ItemName,-20} {ip.Price}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            do
            {
                int choice = Utilities.GetID("\nChoose an item by ID (0 to quit): ");

                if (itemIDs.Contains(choice) || choice == 0)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Not a valid choice!");
                }
            } while (true);
        }

        public static void ProcessPayment(IOrderUpdateService service)
        {
            int choice = ViewOrdersAndGetOrderID(service);

            if (choice == 0)
            {
                return;
            }

            var subTotalResult = service.GetSubTotals(choice);

            if (subTotalResult.Ok)
            {
                decimal? tip = subTotalResult.Data.Tip;

                if (tip == null)
                {
                    tip = 0;
                }

                Console.Clear();
                Console.WriteLine($"Order Totals");
                Console.WriteLine(new string('=', 80));
                Console.WriteLine($"| Sub Total: {subTotalResult.Data.SubTotal:c} | Tax: {subTotalResult.Data.Tax:c} | Tip: {tip:c} | Amount Due: {subTotalResult.Data.AmountDue:c} |");
                Console.WriteLine(new string('=', 80));

                if (tip > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine($"| Note: A mandatory tip of 15% was added for ordering more than 15 items. |");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine(subTotalResult.Message);
                Utilities.AnyKey();
                return;
            }

            if (Utilities.AddMoreItems("\nWould you like to add a tip? (y/n): "))
            {
                if (subTotalResult.Data.Tip == null)
                {
                    subTotalResult.Data.Tip = Utilities.GetTipAmount();
                    subTotalResult.Data.AmountDue += subTotalResult.Data.Tip;
                }
                else
                {
                    decimal tipAddOn = Utilities.GetTipAmount();
                    subTotalResult.Data.Tip += tipAddOn;
                    subTotalResult.Data.AmountDue += tipAddOn;
                }

                Console.WriteLine("\n------------------------------------");
                Console.WriteLine($"Tip Amount: {subTotalResult.Data.Tip:c}");
                Console.WriteLine($"New Amount Due: {subTotalResult.Data.AmountDue:c}");
                Console.WriteLine("------------------------------------\n");
                Console.WriteLine("Press any key to process payment...");
                Console.ReadKey();
            }

            var result = service.GetPaymentTypes();

            if (result.Ok)
            {
                Menus.PaymentHeader();

                foreach (var pt in result.Data)
                {
                    if (pt.PaymentTypeID != 6)
                    {
                        Console.WriteLine($"{pt.PaymentTypeID, -5} {pt.PaymentTypeName}");
                    }
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            int payID;

            do
            {
                payID = Utilities.GetID("\nSelect a payment type ID (0 to quit): ");

                if (payID == 0)
                {
                    return;
                }
                else if (payID <= result.Data.Count())
                {
                    break;
                }

                Console.WriteLine("Invalid ID!");
            } while (true);

            subTotalResult.Data.PaymentTypeID = payID;

            var payResult = service.ProcessPayment(subTotalResult.Data);

            if (payResult.Ok)
            {
                Console.WriteLine("Order is successfully paid!");
            }
            else
            {
                Console.WriteLine(payResult.Message);
            }

            Utilities.AnyKey();
        }
    }
}