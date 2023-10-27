
namespace ConsoleJson.Models
{
    #region Public Class CalculatedAmounts

    /// <summary>
    /// Модель для объекта CalculatedAmounts
    /// </summary>
    public class CalculatedAmounts
    {
        #region Public Fields
        public decimal TotalAmount { get; set;}
        public decimal DiscountAmount { get; set;}
        public decimal TaxAmount { get; set;}
        public decimal SubTotalAmount { get; set;}
        public decimal CartDiscountAmount { get; set;}
        public string? DeliveryFeeAmount { get; set;}
        #endregion
    }
    #endregion
}
