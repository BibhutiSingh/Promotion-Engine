using Promotion_Engine.Core.Entities;
using System;

namespace Promotion_Engine.Core.Interfaces
{
    public interface IPromotion
    {
        Order ApplyPromotion(Order order);
    }
}
