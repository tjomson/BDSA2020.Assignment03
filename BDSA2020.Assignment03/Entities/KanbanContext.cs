using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2020.Assignment03.Entities
{
    public class KanbanContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskTag> TaskTags {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(@"Server=localhost;Database=kanban;Trusted_Connection=True");
            options.EnableSensitiveDataLogging();
        }

        /*ICollection<TaskTag> ConvertToTaskTag(string taskTitle, params string[] tags)
        {
            var taskDict = Tasks.ToDictionary(x => x.Title, x => x.Id);
            var tagDict = Tags.ToDictionary(x => x.Name, x => x.Id);

            var output = from tag in tags
                let taskId = taskDict[taskTitle]
                let tagId = tagDict[tag]
                select new TaskTag {TaskId = taskId, TagId = tagId};

            return output.ToList();
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            modelBuilder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Task>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskTag>().HasKey(a => new {a.TaskId, a.TagId});
            modelBuilder.Entity<Task>().Property(t => t.TaskState).HasConversion(v => v.ToString(),v => (State)Enum.Parse(typeof(State), v));


            var tasks = new[]{
                new Task {Id = 1, Title = "Do something", TaskState = State.ACTIVE}, 
                new Task {Id = 2, Title = "do more", TaskState = State.RESOLVED}
            };

            var tags = new[]{
                new Tag {Id = 1, Name = "tag1"},
                new Tag {Id = 2, Name = "tag2"},
                new Tag {Id = 3, Name = "tag3"}
            };

            var users = new[]{
                new User {Id = 1, Name = "John", Email = "john@email.dk", Tasks = null},
                //new User {Id = 2, Name = "Morten", Email = "morten@email.dk", Tasks = tasks}
            };

            var taskTag = new[]{
                new TaskTag {TagId = 1, TaskId = 1},
                new TaskTag {TagId = 2, TaskId = 1},
                new TaskTag {TagId = 3, TaskId = 2}
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Task>().HasData(tasks);
            modelBuilder.Entity<Tag>().HasData(tags);
            modelBuilder.Entity<TaskTag>().HasData(taskTag);
            
        }
    }
}
