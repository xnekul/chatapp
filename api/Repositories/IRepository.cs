using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Repositories
{
    public interface IRepository<TModel> where TModel : class, IEntity
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel?> GetByIdAsync(int id);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<bool> ExistsAsync(int id);
        Task<TModel> CreateAsync(TModel model);
        Task<TModel?> UpdateAsync(TModel model);
    }
}