using FleskBtocBackend.DTOs;
using System.Threading.Tasks;

namespace FleskBtocBackend.Services
{
    public interface IUserService
    {
        Task<AuthResult> Register(UserRegisterDto registerDto);
        Task<AuthResult> Login(UserLoginDto loginDto);
    }
}
