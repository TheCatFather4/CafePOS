using System.ComponentModel.DataAnnotations;

namespace CafePOS.Core.Entities
{
    public class CafeOrder
    {
        [Key]
        public int OrderID { get; set; }
        public int? ServerID { get; set; }
        public int PaymentTypeID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Tip { get; set; }
        public decimal? AmountDue { get; set; }

        public Server? Server { get; set; }
    }
}