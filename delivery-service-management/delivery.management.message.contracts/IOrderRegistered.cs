﻿namespace delivery.management.message.contracts
{
    public interface IOrderRegistered
    {
        int OrderId { get; }
        string PickupName { get; }
        string PickupAddress { get; }
        string PickupCity { get; }

        string DeliverName { get; }
        string DeliverAddress { get; }
        string DeliverCity { get; }

        int Weight { get; }
        bool Fragile { get; }
        bool Oversized { get; }
    }
}