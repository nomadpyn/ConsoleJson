
namespace ConsoleJson.Models
{
    public class JsonOrder
    {
        public Guid id { get; set; }
        public string? number { get; set; }
        public int LocationId { get; set; }
        public int PosId { get; set; }
        public int Status { get; set; }

        public List<Taxe> Taxes { get; set; } = new();

        public List<LineItem> LineItems { get; set; } = new();
    }
}
