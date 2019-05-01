using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// DataBase Context
        /// </summary>
        private readonly MedicalExaminationContext _context;

        /// <summary>
        /// Entity 
        /// </summary>
        private readonly DbSet<TEntity> _entities;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected GenericRepository(MedicalExaminationContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets all values of entity
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.AsEnumerable();
        }

        /// <summary>
        /// Gets value by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById<TValue>(TValue id)
        {
            return _entities.Find(id);
        }

        /// <summary>
        /// Insert item into
        /// </summary>
        /// <param name="entity"></param>
        public TEntity Insert(TEntity entity)
        {
            var result = _entities.Add(entity);
            SaveChanges();
            return result.Entity;
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }   

        /// <summary>
        /// Updates item
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            _entities.Update(entity);
            SaveChanges();
        }

        /// <summary>
        /// Deletes item
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
