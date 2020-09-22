using BDSA2020.Assignment03.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BDSA2020.Assignment03
{
    public class TasksRepository : IDisposable
    {
        private readonly KanbanContext _context;

        public TasksRepository(KanbanContext context)
        {
            _context = context;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="task"></param>
        /// <returns>The id of the newly created task</returns>
        public int Create(TaskDTO task)
        {

            var assignedToUser = 
                from User in _context.Users
                where User.Id == 1
                select User;

            _context.Tasks.Add(
                new Task {
                    Id = task.Id, 
                    Title = task.Title, 
                    Description = task.Description, 
                    AssignedTo = assignedToUser.First(), 
                    TaskState = task.State});

            if (task.AssignedToId == null)
            {
                throw new NullReferenceException();
            }

            return (int) task.AssignedToId;
        }

        public TaskDetailsDTO FindById(int id)
        {
            var foundTask =
                from task in _context.Tasks
                where task.Id == id
                select task;
            
            var foundUser =
                from user in _context.Users
                where user.Id == foundTask.First().AssignedTo.Id //Noget galt her
                select user;

            var foundTagIds =
                from tasktag in _context.TaskTags
                where tasktag.TaskId == foundTask.First().Id
                select tasktag;

            List<TaskTag> asList = foundTagIds.ToList();
            List<int> ids = new List<int>();
            foreach (var tasktag in asList)
            {
                ids.Add(tasktag.TagId);
            }

            var foundTags =
                from tag in _context.Tags
                where ids.Contains(tag.Id)
                select tag;

            var tags = new List<string>();

            foreach (var tag in foundTags)
            {
                tags.Add(tag.Name);
            }

            return new TaskDetailsDTO {
                Id = id,
                Title = foundTask.First().Title,
                Description = foundTask.First().Description,
                AssignedToId = foundUser.First().Id,
                AssignedToName = foundUser.First().Name,
                AssignedToEmail = foundUser.First().Email,
                Tags = tags,
                State = foundTask.First().TaskState
                };
        }

        public ICollection<TaskDTO> All()
        {
            List<TaskDTO> allTasks = new List<TaskDTO>();

            var taskIds = 
                from task in _context.Tasks
                select task;

            var asList = taskIds.ToList();

            foreach (var task in asList)
            {
                var tagIds = 
                    from tasktag in _context.TaskTags
                    where tasktag.TaskId == task.Id
                    select tasktag.TagId;
                
                var tagIdsAsList = tagIds.ToList();

                var tags = 
                    from tag in _context.Tags
                    where tagIdsAsList.Contains(tag.Id)
                    select tag.Name;

                var tasksAsList = tags.ToList();

                allTasks.Add(new TaskDTO{
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    AssignedToId = task.AssignedTo.Id,
                    Tags = tasksAsList,
                    State = task.TaskState
                });
            }
            return allTasks;
        }

        public void Update(TaskDTO task)
        {
            throw new NotImplementedException();
        }

        public void Delete(int taskId)
        {
            
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
