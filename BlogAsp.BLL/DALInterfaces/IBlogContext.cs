using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BlogAsp.BLL.DALInterfaces
{
    public interface IBlogContext:IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}