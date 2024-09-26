using Microsoft.AspNetCore.Identity;
using ToDoAsp.Config;
using ToDoAsp.Dao.Interface;
using ToDoAsp.Dao.Repository;
using ToDoAsp.Models;

namespace ToDoAsp.Dao.Service
{
    public class TasksService : ITasks
    {
        private TasksRepository _taskRepository;
        private ApplicationDbContext _context;
        public TasksService(TasksRepository taskRepository, ApplicationDbContext dbContext)
        {
            _taskRepository = taskRepository;
            _context = dbContext;
        }

        public void CloseTask(Tasks taskChange)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Tasks taskDlt)
        {
            _taskRepository.DeleteTask(taskDlt);
        }

        public List<Tasks> GetAllTasks(string userid)
        {
            return _taskRepository.GetAllTasks(userid);
        }

        public Tasks NewTask(Tasks newTask)
        {
            return _taskRepository.NewTask(newTask);
        }
    }
}
