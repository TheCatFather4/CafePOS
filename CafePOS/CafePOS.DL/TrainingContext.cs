using CafePOS.Core.Entities;

namespace CafePOS.DL
{
    public class TrainingContext
    {
        public static List<CafeOrder> CafeOrders = new List<CafeOrder>
        {
            new CafeOrder { OrderID = 1, ServerID = 1, PaymentTypeID = 1, OrderDate = new DateTime(2025, 1, 10), SubTotal = 20M, Tax = 0.1M, Tip = 5M, AmountDue = 25.1M },
            new CafeOrder { OrderID = 2, ServerID = 1, PaymentTypeID = 2, OrderDate = new DateTime(2025, 1, 10), SubTotal = 50M, Tax = 0.5M, Tip = 10M, AmountDue = 60.5M },
            new CafeOrder { OrderID = 3, ServerID = 1, PaymentTypeID = 6, OrderDate = new DateTime(2025, 4, 3) }
        };

        public static List<Category> Categories = new List<Category> 
        {
           new Category { CategoryID = 1, CategoryName = "Appetizers" },
           new Category { CategoryID = 2, CategoryName = "Beverages"}
        };

        public static List<Item> Items = new List<Item>
        {
            new Item { ItemID = 1, CategoryID = 1, ItemName = "Jalapeno Poppers" },
            new Item { ItemID = 2, CategoryID = 2, ItemName = "Coffee"}
        };

        public static List<ItemPrice> ItemPrices = new List<ItemPrice>
        {
            new ItemPrice { ItemPriceID = 1, ItemID = 1, Price = 3.00M },
            new ItemPrice { ItemPriceID = 2, ItemID = 2, Price = 3.50M }
        };

        public static List<OrderItem> OrderItems = new List<OrderItem>
        {
            new OrderItem { OrderItemID = 1, OrderID = 1, ItemPriceID = 1, Quantity = 2, ExtendedPrice = 6.00M},   
            new OrderItem { OrderItemID = 2, OrderID = 2, ItemPriceID = 2, Quantity = 3, ExtendedPrice = 10.50M}
        };

        public static List<PaymentType> PaymentTypes = new List<PaymentType>
        {
            new PaymentType { PaymentTypeID = 1, PaymentTypeName = "Visa"},
            new PaymentType { PaymentTypeID = 2, PaymentTypeName = "Mastercard"}
        };

        public static List<Server> Servers = new List<Server>
        {
            new Server { ServerID = 1, FirstName = "Luke", LastName = "McGluke"}
        };
    }
}