using System;
using System.Collections.Generic;
using Warehouse.Models;

namespace Warehouse.DataAccess
{
    public interface IRepository<T> where T : IEntityWithId
    {
        T AddEntity(T entity);
        void DeleteEntity(Guid id);
        IEnumerable<T> GetEntities(int offset, int count);
        T GetEntity(Guid id);
        T UpdateEntity(Guid id, T entity);
    }
}