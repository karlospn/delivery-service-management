using delivery.management.message.contracts;

namespace delivery.management.registration.service.Models
{
    public class NotificationOrderModel : IOrderRegistered
    {
        public int OrderId { get; set; }
        public string PickupName { get; set; }
        public string PickupAddress { get; set; }
        public string PickupCity { get; set; }
        public string DeliverName { get; set; }
        public string DeliverAddress { get; set; }
        public string DeliverCity { get; set; }
        public int Weight { get; set; }
        public bool Fragile { get; set; }
        public bool Oversized { get; set; }
    }
}
