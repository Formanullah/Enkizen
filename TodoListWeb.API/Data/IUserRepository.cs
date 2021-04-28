using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Data
{
    public interface IUserRepository
    {
          Task<bool> IsUserExists(int userId);

          Task<bool> IsExistTask(int id);

          Task<Tasks> GetTaskById(int id);
          Task<ICollection<Tasks>> GetTodatsTaskByUserId(int userId);

          Task<bool> SaveAll();
    }
}