using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;

namespace api.Mappers
{
    public class MessageEntityMapper : IEntityMapper<MessageEntity>
    {
        public void MapToExistingEntity(MessageEntity existingEntity, MessageEntity newEntity)
        {
            existingEntity.Content = newEntity.Content;
            existingEntity.Date = newEntity.Date;
        }
    }
}