using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TododbContext _context;
        public AuthRepository(TododbContext context)
        {
            _context = context;

        }
        public async Task<Users> Login(string email, string password)
        {
            var user = await _context.Users.Include(r => r.Role).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512(passwordSalt)) //for hashing password using password sslt
            {
                var computedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    return false;
                }
            }
            return true;
        }

        public async Task<Users> Register(Users user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash=passwordHash;
            user.PasswordSalt=passwordSalt;

            await _context.Users.AddAsync(user); //save user
            await _context.SaveChangesAsync();//save changes back to the database
            return user;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using (var hmac= new System.Security.Cryptography.HMACSHA512()) //for hashing password
            {
                passwordSalt=hmac.Key; //rendomly generate key
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> IsUserExists(string email)
        {
            if(await _context.Users.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }
    }
}