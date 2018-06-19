using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using ReKreator.Data.Context;

namespace ReKreator.Data.Core.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> entities;

        public Repository(ReKreatorContext context) => entities = context.Set<T>();
        public IEnumerable<T> GetAll() => entities;
        public T GetItem(int id) => entities.Find(id);
        public void Create(T item) => entities.AddOrUpdate(item);
        public void Update(T item) => entities.AddOrUpdate(item);
        public void Delete(int id)
        {
            var item = GetItem(id);
            if (item != null)
                entities.Remove(item);
        }
    }
}
