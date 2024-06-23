using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Mappers
{
    public class RoomEntityMapper : IEntityMapper<RoomEntity>
    {
        public void MapToExistingEntity(RoomEntity existingEntity, RoomEntity newEntity)
        {
            existingEntity.Name = newEntity.Name;
        }
    }
}