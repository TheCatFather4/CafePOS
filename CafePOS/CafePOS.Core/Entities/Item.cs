namespace CafePOS.Core.Entities
{
    public class Item
    {
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}