namespace Promotion_Engine.Core.Entities
{
    public abstract class PromotionItem : EntityBase
    {
        public string Name { get; set; }
        public Product MainProduct { get; set; }
    }
}
