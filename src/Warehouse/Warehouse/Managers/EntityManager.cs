using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DataAccess;
using Warehouse.Models;

namespace Warehouse.Managers
{
    public class EntityManager<T> where T : IEntityWithId
    {
        private IRepository<T> repository;

        // add cache here

        public EntityManager(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Add(T entity) => repository.AddEntity(entity);

        public void Delete(Guid id) => repository.DeleteEntity(id);

        public IEnumerable<T> Get(int offset, int count) => repository.GetEntities(offset, count);

        public T Get(Guid id) => repository.GetEntity(id);

        public T UpdateEntity(Guid id, T entity) => repository.UpdateEntity(id, entity);
    }
}
