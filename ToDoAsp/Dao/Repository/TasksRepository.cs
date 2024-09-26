using Microsoft.AspNetCore.Identity;
using ToDoAsp.Config;
using ToDoAsp.Dao.Interface;
using ToDoAsp.Models;

namespace ToDoAsp.Dao.Repository
{
    public class TasksRepository : ITasks
    {
        private readonly ApplicationDbContext _context;

        public TasksRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CloseTask(Tasks taskChange)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Tasks taskDlt)
        {
            _context.Remove(taskDlt);
            _context.SaveChanges();
        }

        public List<Tasks> GetAllTasks(string userid)
        {
            return _context.Tasks
                .Where(task => task.OwnerId == userid)
                .ToList();
        }

        public Tasks NewTask(Tasks newTask)
        {
            var savedTask = _context.Tasks.Add(newTask);
            _context.SaveChanges();

            return newTask;
        }
    }
}
