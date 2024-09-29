using web_api.DTOs;
using web_api.Models;

namespace web_api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);

        void Register(UserRegistrationDto registrationDto);
        Task<bool> UserAlreadyExist(string username);


    }
}
