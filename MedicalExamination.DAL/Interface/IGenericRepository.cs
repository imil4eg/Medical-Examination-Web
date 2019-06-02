using System.Collections.Generic;
using System.Linq;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> : IRepository where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById<TValue>(TValue id);
        TEntity Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    }
}
