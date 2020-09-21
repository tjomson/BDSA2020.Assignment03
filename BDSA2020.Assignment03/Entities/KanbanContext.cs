using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace BDSA2020.Assignment03.Entities
{
    public class KanbanContext : DbContext
    {
  /*      public KanbanContext(DbContextOptions<KanbanContext> options)
            : base(options)
            { }
*/
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskTag> TaskTags {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost;Database=kanban;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            modelBuilder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Task>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskTag>().HasNoKey();
            modelBuilder.Entity<Task>().Property(t => t.TaskState).HasConversion(v => v.ToString(),v => (State)Enum.Parse(typeof(State), v));

        }
    }
}
