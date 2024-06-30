using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasMany(s => s.Rooms)
                .WithMany(c => c.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoom",
                    j => j.HasOne<RoomEntity>().WithMany().HasForeignKey("RoomId"),
                    j => j.HasOne<UserEntity>().WithMany().HasForeignKey("UserId"));

            modelBuilder.Entity<RoomEntity>()
            .HasMany(e => e.Messages)
            .WithOne(e => e.Room)
            .HasForeignKey(e => e.RoomId)
            .IsRequired();

            modelBuilder.Entity<UserEntity>()
            .HasMany(e => e.Messages)
            .WithOne(e => e.Author)
            .HasForeignKey(e => e.AuthorId)
            .IsRequired();

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }


}