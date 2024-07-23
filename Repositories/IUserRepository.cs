using FleskBtocBackend.Models;
using System.Threading.Tasks;

namespace FleskBtocBackend.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task AddUser(User user);
    }
}
