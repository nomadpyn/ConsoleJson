
namespace ConsoleJson.Models
{
    public class LineItem
    {
        public string? Name { get; set; }
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public CalculatedAmounts CalculatedAmounts { get; set; } = new();
    }
}
