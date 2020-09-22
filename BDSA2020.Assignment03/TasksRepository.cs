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
                    AssignedToId = assignedToUser.First().Id, 
                    TaskState = task.State});
            
            AddTagsForTask(task);

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
                where user.Id == foundTask.First().AssignedToId //Noget galt her
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

        //Untested
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
                    AssignedToId = task.AssignedToId,
                    Tags = tasksAsList,
                    State = task.TaskState
                });
            }
            return allTasks;
        }

        public void Update(TaskDTO task)
        {
            var givenTask =
                from t in _context.Tasks
                where t.Id == task.Id
                select t;

            var taskObject = givenTask.FirstOrDefault();

            taskObject.Title = task.Title;
            taskObject.Description = task.Description;
            taskObject.AssignedToId = task.AssignedToId;
            taskObject.TaskState = task.State;
            //Doesn't remove unnecessary tags in TaskTag
/*
            var taskTagsToBeRemoved =
                from tasktag in _context.TaskTags
                where tasktag.TaskId == task.Id
                
                select tasktag;

            foreach (var tasktag in taskTagsToBeRemoved)
            {
                _context.TaskTags.Remove(tasktag);
            }
*/
            AddTagsForTask(task);

        }

        public void Delete(int taskId)
        {
            var toBeDeleted = 
                from task in _context.Tasks
                where task.Id == taskId
                select task;

            _context.Tasks.Remove(toBeDeleted.FirstOrDefault());

        //Doesn't remove unnecessary tags in TaskTag
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void AddTagsForTask(TaskDTO task)
        {
            var taskIds =
                from taskk in _context.Tasks
                select taskk.Id;

            var maxId = taskIds.Max();
            List<int> addedIds = new List<int>();
            var counter = 1;

            foreach (var tagName in task.Tags)
            {
                addedIds.Add(maxId + counter);
                _context.Tags.Add(new Tag {Id = maxId + counter, Name = tagName});
                counter++;
            }

            foreach (var id in addedIds)
            {
                _context.TaskTags.Add(new TaskTag{TaskId = task.Id, TagId = id});
            }
        }
    }
}
