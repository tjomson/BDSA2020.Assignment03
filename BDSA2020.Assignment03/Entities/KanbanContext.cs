using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost;Database=kanban;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
             //modelBuilder.Entity<KanbanContext>().ToTable("Kanban"); "Kanban" = table name
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            
        }
    }
}
