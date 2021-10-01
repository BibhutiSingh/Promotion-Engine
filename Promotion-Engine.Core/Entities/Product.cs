namespace Promotion_Engine.Core.Entities
{
    /// <summary>
    /// Base SKU
    /// </summary>
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
