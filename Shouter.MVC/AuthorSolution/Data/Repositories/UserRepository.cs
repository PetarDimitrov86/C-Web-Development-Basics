﻿namespace Shouter.Data.Repositories
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Contracts;
    using Models;
    public class UserRepository : Repository<User>
    {
        public UserRepository(IShouterContext context) 
            : base(context)
        {

        }

        public User FindUserByUserName(string username)
        {
           return this.EntityTable.FirstOrDefault(u=>u.Username == username);
        }

        public void AddOrUpdateUser(User user)
        {
            this.EntityTable.AddOrUpdate(user);
        }
    }
}
