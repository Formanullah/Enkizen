using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Data
{
    public class UserRepository : IUserRepository
    {
          private readonly TododbContext _context;
        public UserRepository(TododbContext context)
        {
            _context = context;

        }
       public async Task<ICollection<Tasks>> GetTodatsTaskByUserId(int userId)
        {
            var tasks = await _context.Tasks.Where(task => task.UserId == userId & task.CreatedDate == DateTime.Today & task.IsDeleted != true).ToListAsync();
            return tasks;
        }

        public async Task<Tasks> GetTaskById(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            return task;
        }


         public async Task<bool> IsExistTask(int id)
        {
            if(await _context.Tasks.AnyAsync(u => u.Id == id))
                return true;

            return false;
        }

        public async Task<bool> IsUserExists(int userId)
        {
            if(await _context.Users.AnyAsync(u => u.Id == userId))
                return true;

            return false;
        }

         public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}