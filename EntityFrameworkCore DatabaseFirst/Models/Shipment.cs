using System;
using System.Collections.Generic;

namespace EntityFrameworkCore_DatabaseFirst.Models
{
    public partial class Shipment
    {
        public int ShippingId { get; set; }
        public string? Location { get; set; }
        public DateTime? ExpectedDelivery { get; set; }
    }
}
