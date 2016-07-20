using System;
using DataAccess.Users;
using DemoApp.Commonm;

namespace DemoApp.Core.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public UserInfo GetUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId");
            }
            return this.usersRepository.GetUser(userId);
        }

        public UserInfo GetUser(UserInfo user)
        {
            user.Password = HashingUtility.GetHash(user.Password);
            return this.usersRepository.GetUser(user);
        }

        public bool IsUserExists(string userId)
        {
            return this.usersRepository.IsUserExists(userId);
        }

        public bool RegisterNewUser(UserInfo model)
        {
            model.Password = HashingUtility.GetHash(model.Password);
             return this.usersRepository.AddUser(model);
        }
    }
}
