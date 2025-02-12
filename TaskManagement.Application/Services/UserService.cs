using TaskManagement.Application.Common.DTOs;
using TaskManagement.Application.Common.Mappers;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var usersData = await _userRepository.GetAllUsers();
            return usersData.Select(u => u.ToDto()).ToList();
        }

    }
}
