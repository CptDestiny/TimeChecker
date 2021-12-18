using System.Collections.Generic;
using System.Linq;
using TodoManager.BL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TodoManager.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public IEnumerable<T> GetPagedData<T>(IQueryable<T> data, int pageSize, int page)
            where T : class, new()
        {
            return data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .HasKey(c => new { c.Id });

            modelBuilder.Entity<TodoItem>()
                .Property(x => x.Completed)
                .HasDefaultValue(false);

            modelBuilder.Entity<TodoItem>().HasData(new List<TodoItem>()
            {
                new() {Id = -1, Type = 2, Comment = "I have to do xyz", Completed = false}
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
