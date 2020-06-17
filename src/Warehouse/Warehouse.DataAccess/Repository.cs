using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Models;
using System.Linq;

namespace Warehouse.DataAccess
{
    public class Repository<T> : IRepository<T> where T : IEntityWithId
    {
        public List<T> store = new List<T>();

        public T GetEntity(Guid id) => store.Find(e => e.Id == id);

        public IEnumerable<T> GetEntities(int offset, int count) => store.Skip(offset).Take(count);

        public T AddEntity(T entity)
        {
            entity.Id = Guid.NewGuid();
            store.Add(entity);
            return entity;
        }

        public T UpdateEntity(Guid id, T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Guid id)
        {
            var index = store.FindIndex(e => e.Id == id);
            if (index >= 0)
                store.RemoveAt(index);
        }
    }
}
