using FleskBtocBackend.Models;

namespace FleskBtocBackend.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
