using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Models
{
    public class Customer : IEntityWithId
    {
        public Guid Id { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
