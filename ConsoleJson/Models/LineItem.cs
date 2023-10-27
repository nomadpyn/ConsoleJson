
namespace ConsoleJson.Models
{
    #region Public Class LineItem

    /// <summary>
    /// Модель для обьекта LineItem
    /// </summary>
    public class LineItem
    {
        #region Public Fields
        public string? Name { get; set; }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public CalculatedAmounts CalculatedAmounts { get; set; } = new();
        #endregion
    }
    #endregion
}
