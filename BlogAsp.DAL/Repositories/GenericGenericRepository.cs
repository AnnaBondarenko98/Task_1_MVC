using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlogAsp.BLL.DALInterfaces;

namespace BlogAsp.DAL.Repositories
{
    /// <summary>
    /// Implementing of common repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IBlogContext _database;

        public GenericGenericRepository(IBlogContext database)
        {
            _database = database;
        }

        public void Create(T item)
        {
            _database.Set<T>().Add(item);
            _database.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _database.Set<T>().Find(id);

            if (item != null)
            {
                _database.Set<T>().Remove(item);
                _database.SaveChanges();
            }
        }

        public T Get(int id)
        {
            return _database.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _database.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _database.Entry(item).State = EntityState.Modified;
            _database.SaveChanges();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _database.Set<T>().Where(predicate).ToList();
        }
    }
}
