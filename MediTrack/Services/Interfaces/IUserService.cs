using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int userId);
        Task<UserDto?> GetUserByEmailAsync(string email);
        Task<UserDto> CreateUserAsync(UserRegisterDto dto);
        Task<UserDto> UpdateUserAsync(UserDto dto);
        Task<bool> DeleteUserAsync(int userId);
    }
}
