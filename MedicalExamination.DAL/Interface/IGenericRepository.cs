using System.Collections.Generic;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> : IRepository where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById<TValue>(TValue id);
        TEntity Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
