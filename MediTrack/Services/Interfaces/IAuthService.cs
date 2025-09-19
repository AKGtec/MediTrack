using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserDto user);
    }
}