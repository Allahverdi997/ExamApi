using Domain.Abstract.Marker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Context
{
    public interface ISqlDbContext
    {
        ChangeTracker ChangeTracker { get; }

        EntityEntry Entry<T>(T entity);

        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEntity;

        void SaveChanges();
        Task SaveChangesAsync();

        Task DisposeContext();
    }
}
