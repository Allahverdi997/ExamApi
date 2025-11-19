using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System.Linq.Expressions;

namespace Application.Abstraction.Repository.Core
{
    public interface ISqlGenericWriteRepository<T> : IRepository<T> where T :  BaseEntity
    {
        #region Insert
        Task AddAsync(T entity);
        void Add(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        void AddRange(IEnumerable<T> entity);
        #endregion

        #region Update
        Task UpdateAsync(T entity);
        void Update(T entity);
        #endregion

        #region Delete
        Task DeleteAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
        void Delete(int id);
        Task DeleteRangeAsync(Expression<Func<T, bool>> expression);
        void DeleteRange(Expression<Func<T, bool>> expression);
        #endregion

        #region AddOrUpdate
        Task AddOrUpdateAsync(T entity, int id);
        void AddOrUpdate(T entity, int id);
        #endregion

        #region SaveChanges
        Task SaveChangesAsync();
        void SaveChanges();
        #endregion
    }
}
