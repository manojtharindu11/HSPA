using web_api.Models;

namespace web_api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);

        void Register(string username, string password);
        Task<bool> UserAlreadyExist(string username);


    }
}
