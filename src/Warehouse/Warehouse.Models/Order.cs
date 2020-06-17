using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Models
{
    public class Order : IEntityWithId
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid CommodityId { get; set; }

        public int Quantity { get; set; }
    }
}
