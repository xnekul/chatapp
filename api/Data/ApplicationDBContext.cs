using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany(s => s.Rooms)
                .WithMany(c => c.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoom",
                    j => j.HasOne<RoomEntity>().WithMany().HasForeignKey("StudentId"),
                    j => j.HasOne<UserEntity>().WithMany().HasForeignKey("UserId"));
        }

    }


}