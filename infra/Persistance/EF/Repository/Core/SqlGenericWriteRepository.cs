using Application.Abstraction.Context;
using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Core;
using Domain.Concrete.Base.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EF.Repository.Core
{
    public class SqlGenericWriteRepository<T> : ISqlGenericWriteRepository<T> where T : BaseEntity
    {
        public ISqlDbContext Context;
        public SqlGenericWriteRepository(ISqlDbContext context)
        {
            Context = context;
        }

        public DbSet<T> Table => Context.GetDbSet<T>();

        #region Insert
        public void Add(T entity)
        {
            try
            {
                Table.Add(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }
        }
        public async Task AddAsync(T entity)
        {
            try
            {
                await Table.AddAsync(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                Table.AddRange(entities);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await Table.AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
               // throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }
        }
        #endregion
        #region AddOrUpdate

        public void AddOrUpdate(T entity, int id = 0)
        {
            try
            {
                if (id == 0)
                    Add(entity);
                else
                    Update(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }
        }

        public async Task AddOrUpdateAsync(T entity, int id = 0)
        {
            try
            {
                if (id == 0)
                    await AddAsync(entity);
                else
                    await UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }
        }
        #endregion
        #region Delete
        public void Delete(T entity)
        {
            try
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    Table.Attach(entity);

                Table.Remove(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public void Delete(int id)
        {
            try
            {
                var entity = Table.Find(id);
                Delete(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    Table.Attach(entity);

                Table.Remove(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await Table.FindAsync(id);
                await DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public void DeleteRange(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            try
            {
                IEnumerable<T> entities = Table.Where(expression).ToList();
                foreach (T entity in entities)
                    Delete(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task DeleteRangeAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            try
            {
                IEnumerable<T> entities = await Table.Where(expression).ToListAsync();
                foreach (T entity in entities)
                    await DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        #endregion
        #region SaveChanges
        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        #endregion
        #region Update

        public void Update(T entity)
        {
            try
            {
                Table.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                Table.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                //throw new ServerErrorException(ExceptionEnum.ServerErrorException.ToString(), ex, false);
            }

        }
        #endregion
    }
}
