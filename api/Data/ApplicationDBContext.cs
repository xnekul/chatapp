using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages{ get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(s => s.Rooms)
                .WithMany(c => c.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoom",
                    j => j.HasOne<Room>().WithMany().HasForeignKey("StudentId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));
        }

    }


}