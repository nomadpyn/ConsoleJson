
namespace ConsoleJson.Models
{
    #region Public Class Taxe

    /// <summary>
    /// Модель для объекта Taxe
    /// </summary>
    public class Taxe
    {
        #region Public Fields
        public Guid Id { get; set; }
        public Guid InventoryTaxId { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public int FederalType { get; set; }
        public bool Default { get; set; }
        public int Scope {  get; set; }
        public int Receiver {  get; set; }
        public int Type { get; set; }
        public string[] Attribute { get; set; }
        #endregion
    }
    #endregion
}
