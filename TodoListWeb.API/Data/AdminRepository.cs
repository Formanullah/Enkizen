using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Data
{
    public class AdminRepository : IAdminRepository
    {
       private readonly TododbContext _context;
        public AdminRepository(TododbContext context)
        {
            _context = context;

        }
         public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<ICollection<Tasks>> GetTodatsTaskByUserId(int userId)
        {
            var tasks = await _context.Tasks.Where(task => task.UserId == userId & task.CreatedDate == DateTime.Today & task.IsDeleted != true).ToListAsync();
            return tasks;
        }

        public async Task<ICollection<Tasks>> GetCompletedTasks()
        {
            var tasks = await _context.Tasks.Include(u => u.User).AsNoTracking().Where(task => task.IsDone == true & task.IsDeleted != true).ToListAsync();
            return tasks;
        }

        public async Task<Tasks> GetTaskById(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            return task;
        }

        public async Task<ICollection<Tasks>> GetTasks()
        {
            var tasks = await _context.Tasks.Include(u => u.User).AsNoTracking().ToListAsync();
            return tasks;
        }

        public async Task<ICollection<Users>> GetUsers()
        {
            var users = await _context.Users.Include(u => u.Role).AsNoTracking().ToListAsync();
            return users;
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