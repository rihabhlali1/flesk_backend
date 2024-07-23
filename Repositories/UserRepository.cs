using FleskBtocBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FleskBtocBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Data.ApplicationDbContext _context;

        public UserRepository(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
