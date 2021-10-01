using Promotion_Engine.Core.Entities;
using System;

namespace Promotion_Engine.Core.Interfaces
{
    public interface IPromotion
    {
        (decimal total, Order cart) ApplyPromotion(Order order);
    }
}
