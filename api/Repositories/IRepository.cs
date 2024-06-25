using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<bool> ExistsAsync(int id);
        Task<TEntity> CreateAsync(TEntity model);
        Task<TEntity?> UpdateAsync(TEntity model);
    }
}