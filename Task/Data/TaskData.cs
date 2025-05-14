using System.Collections.Generic;
using System.Linq;
using SimpleTaskManagerAPI.Models;

namespace SimpleTaskManagerAPI.Data
{
    public class TaskData
    {
        private readonly TaskDbContext _dbContext;

        public TaskData(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TaskItem> GetAllTasks()
        {
            return _dbContext.Tasks.OrderBy(t => t.Id).ToList();
        }

        public TaskItem? GetTaskById(int id)
        {
            return _dbContext.Tasks.Find(id);
        }

        public void AddTask(TaskItem task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }

        public void UpdateTask(TaskItem updatedTask)
        {
            var existingTask = _dbContext.Tasks.Find(updatedTask.Id);
            if (existingTask != null)
            {
                _dbContext.Entry(existingTask).CurrentValues.SetValues(updatedTask);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            var taskToDelete = _dbContext.Tasks.Find(id);
            if (taskToDelete != null)
            {
                _dbContext.Tasks.Remove(taskToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}