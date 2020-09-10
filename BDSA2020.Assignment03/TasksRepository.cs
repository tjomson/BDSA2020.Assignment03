using BDSA2020.Assignment03.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public TaskDetailsDTO FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TaskDTO> All()
        {
            throw new NotImplementedException();
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
