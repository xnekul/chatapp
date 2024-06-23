using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Mappers
{
    public interface IEntityMapper<in TEntity> where TEntity : IEntity
    {
        void MapToExistingEntity(TEntity existingEntity, TEntity newEntity);
    }
}