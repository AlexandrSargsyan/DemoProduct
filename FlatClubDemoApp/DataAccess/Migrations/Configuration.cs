using System.Collections.Generic;
using DemoApp.Commonm;

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.DemoAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DemoAppContext context)
        {
            if(context.Users.Any()) return;
            
            var userOne = new User
            {
                UserId = "example@demoapp.com",
                UserName = "User1",
                Password = HashingUtility.GetHash("Test123456.")
            };
            var userTwo = new User
            {
                UserId = "example2@demoapp.com",
                UserName = "User2",
                Password = HashingUtility.GetHash("Test123456.")
            };
            context.Users.AddOrUpdate(u => u.UserId,
                userOne,
               userTwo,
                new User
                {
                    UserId = "example3@demoapp.com",
                    UserName = "User3",
                    Password = HashingUtility.GetHash("Test123456.")
                });

            var userList = new List<User> {userOne, userTwo};
            var otherList = new List<User> {userTwo};
            context.Groups.AddOrUpdate(new Group
            {
                GroupName = "Art",
                GroupDescription = "Post your stories about arts.",
                Users = userList
                
            }, new Group
            {
                GroupName = "Poems",
                GroupDescription = "Post your stories about Poems.",
               Users = userList
            }, new Group
            {
                GroupName = "Love",
                GroupDescription = "Post your stories about Love.",
                Users = userList
            }, new Group
            {
                GroupName = "Cars",
                GroupDescription = "Post your stories about Cars.",
                Users = otherList
            }, new Group
            {
                GroupName = "Humour",
                GroupDescription = "Post your stories about Humour.",
                     Users = otherList
            }, new Group
            {
                GroupName = "Nature",
                GroupDescription = "Post your stories about Nature.",
                     Users = otherList
            }, new Group
            {
                GroupName = "Aphorisms",
                GroupDescription = "Post your stories about Aphorisms.",
                 Users = otherList
            });

           
        }
    }
}
