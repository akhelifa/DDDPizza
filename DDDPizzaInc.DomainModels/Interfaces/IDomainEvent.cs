using System;

namespace DDDPizzaInc.DomainModels.Events
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}