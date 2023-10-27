
namespace ConsoleJson.Models
{
    public class CalculatedAmounts
    {
        public decimal TotalAmount { get; set;}
        public decimal DiscountAmount { get; set;}
        public decimal TaxAmount { get; set;}
        public decimal SubTotalAmount { get; set;}
        public decimal CartDiscountAmount { get; set;}
        public string? DeliveryFeeAmount { get; set;}
    }
}
