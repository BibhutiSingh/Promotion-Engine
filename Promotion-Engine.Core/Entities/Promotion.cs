namespace Promotion_Engine.Core.Entities
{
    public abstract class Promotion : EntityBase
    {
        public Product MainProduct { get; set; }
    }
}
