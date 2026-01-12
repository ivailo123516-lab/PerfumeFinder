using PerfumeFinder.Api.Models;
using PerfumeFinder.Api.DTOs;

namespace PerfumeFinder.Api.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        User? ValidateUser(string username, string password);
        bool CreateUser(RegisterDto dto);
    }
}
