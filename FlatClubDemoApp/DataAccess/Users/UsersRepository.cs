using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Commonm;

namespace DataAccess.Users
{
    public class UsersRepository : IUsersRepository
    {
        public UserInfo GetUser(string userId)
        {
            using (var dbContext = new DemoAppContext())
            {
                var user = dbContext.Users.SingleOrDefault(u => u.UserId == userId);
                if (user == null) return null;

                var config = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.CreateMap<User, UserInfo>();
                        cfg.CreateMap<Group, GroupInfo>().ForMember(g => g.Users, opt => opt.Ignore());
                    });

                var mapper = config.CreateMapper();
                var userInfo = mapper.Map<UserInfo>(user);

                return userInfo;
            }

        }

        public UserInfo GetUser(UserInfo user)
        {
            using (var dbContext = new DemoAppContext())
            {
                var userData =
                    dbContext.Users.SingleOrDefault(u => u.UserId == user.UserId && u.Password == user.Password);
                if (userData == null) return null;

                var config = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.CreateMap<User, UserInfo>();
                        cfg.CreateMap<Group, GroupInfo>().ForMember(g => g.Users, opt => opt.Ignore());
                    });

                var mapper = config.CreateMapper();
                var userInfo = mapper.Map<UserInfo>(userData);

                return userInfo;
            }

        }


        public bool IsUserExists(string userId)
        {
            using (var dbContext = new DemoAppContext())
            {
                var user = dbContext.Users.SingleOrDefault(u => u.UserId == userId);
                if (user == null) return false;

                return true;
            }
        }

        public bool AddUser(UserInfo model)
        {
            try
            {
                using (var dbContext = new DemoAppContext())
                {
                    var user = new User
                    {
                        UserName = model.UserName,
                        UserId = model.UserId,
                        Password = model.Password
                    };
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }


        }
    }
}

