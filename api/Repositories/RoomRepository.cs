using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class RoomRepository : RepositoryBase<RoomEntity>, IRepository<RoomEntity>
    {
        public RoomRepository(ApplicationDBContext context, IEntityMapper<RoomEntity> entityMapper) : base(context, entityMapper)
        {
        }

        public new async Task<RoomEntity?> GetByIdAsync(int id)
        {
            return await getDbSet().Include(c => c.Messages).FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}