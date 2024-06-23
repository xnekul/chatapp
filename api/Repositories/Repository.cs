using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using api.Mappers;

namespace api.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ApplicationDBContext _context;
        private readonly IEntityMapper<TEntity> _entityMapper;

        public Repository(ApplicationDBContext context, IEntityMapper<TEntity> entityMapper)
        {
            _context = context;
            _entityMapper = entityMapper;
        }

        private DbSet<TEntity> getDbSet()
        {
            return _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await getDbSet().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await getDbSet().FindAsync(id);
        }

        public async ValueTask<bool> ExistsAsync(int id)
        {
            return await getDbSet().FindAsync(id) != null;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var output = getDbSet().Add(entity).Entity;
            await _context.SaveChangesAsync();
            return output;
        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {

            var existingEntity = await getDbSet().FindAsync(entity.Id);

            if (existingEntity == null)
            {
                return null;
            }

            _entityMapper.MapToExistingEntity(existingEntity, entity);

            await _context.SaveChangesAsync();

            return existingEntity;

        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var entity = await getDbSet().FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            getDbSet().Remove(entity); // Remove cannot be async

            await _context.SaveChangesAsync();

            return true;
        }
    }
}