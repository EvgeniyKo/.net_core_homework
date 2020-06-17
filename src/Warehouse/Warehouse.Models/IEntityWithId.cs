using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Models
{
    public interface IEntityWithId
    {
        Guid Id { get; set; }
    }
}
