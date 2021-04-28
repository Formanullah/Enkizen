using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Data
{
    public interface IAdminRepository : IUserRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;

         Task<ICollection<Users>> GetUsers();

         Task<ICollection<Tasks>> GetTasks();
         Task<ICollection<Tasks>> GetCompletedTasks();
    }
}