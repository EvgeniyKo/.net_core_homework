using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Models
{
    public class Commodity : IEntityWithId
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
