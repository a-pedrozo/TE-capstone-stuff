﻿using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password);
        User GetUserByAccountId(int accountId);
        List<User> GetUsers();
    }
}
