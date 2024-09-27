using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using web_api.Data;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;

        public UserRepository(DataContext dataContext)
        {
            dc = dataContext;
        }

        public async Task<User> Authenticate(string username, string passwordText)
        {
            //return await dc.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            var user = await dc.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null || user.Password == null)
            {
                return null;
            }

            if (!MatchPasswordHash(passwordText, user.Password, user.PasswordKey)) { return null; }

            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for (int i = 0;i < passwordHash.Length;i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }
        }

        public void Register(string username, string password)
        {
            byte[] passwordHash, passwordKey;

            using( var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            User user = new User();
            user.UserName = username;
            user.Password = passwordHash;
            user.PasswordKey = passwordKey;

            dc.Users.Add(user);
        }

        public async Task<bool> UserAlreadyExist(string username)
        {
            return await dc.Users.AnyAsync(x => x.UserName == username);
        }
    }
}
