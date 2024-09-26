using Microsoft.AspNetCore.Identity;
using ToDoAsp.Models;

namespace ToDoAsp.Dao.Interface
{
    public interface ITasks
    {
        public Tasks NewTask(Tasks newTask);
        public List<Tasks> GetAllTasks(string userid);
        public void DeleteTask(Tasks taskDelete);

        public void CloseTask(Tasks taskChange);

    }
}
