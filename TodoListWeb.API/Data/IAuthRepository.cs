using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Data
{
    public interface IAuthRepository
    {
         Task<Users> Register(Users user,string password);
         Task<Users> Login(string email,string password);
         Task<bool> IsUserExists(string email);
         
    }
}