using FleskBtocBackend.DTOs;
using FleskBtocBackend.Models;
using FleskBtocBackend.Repositories;
using System.Threading.Tasks;
using BCrypt.Net;

namespace FleskBtocBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResult> Register(UserRegisterDto registerDto)
        {
            try
            {
                var existingUser = await _userRepository.GetUserByUsername(registerDto.Username);
                if (existingUser != null)
                {
                    return new AuthResult { Success = false, Error = "Username already exists" };
                }

                var user = new User
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
                };

                await _userRepository.AddUser(user);

                var token = _jwtTokenGenerator.GenerateToken(user);

                return new AuthResult { Success = true, Token = token };
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in Register: {ex.Message}");
                return new AuthResult { Success = false, Error = "An error occurred during registration." };
            }
        }

        public async Task<AuthResult> Login(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUsername(loginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return new AuthResult { Success = false, Error = "Invalid username or password" };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResult { Success = true, Token = token };
        }
    }
}
