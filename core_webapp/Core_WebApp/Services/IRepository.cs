using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Services
{
    /// <summary>
    /// The interface that will contains async methods for CRUD Operations
    /// This is Mult-Type Generic interface where TEntity will always be 
    /// Entity Class e.g. Category/Product and TPk will always be
    /// input parameter that represents value for Primary Key
    /// to search a record for Update and delete
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IService<TEntity, in TPk> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<bool> DeleteAsync(TPk id);
    }
}
