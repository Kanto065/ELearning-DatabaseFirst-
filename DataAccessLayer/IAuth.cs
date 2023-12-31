﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IAuth
    {
        Token Authenticate(User user);
        bool IsAuthenticated(string token);
        bool IsRoleAuthenticated(string token);
        bool Logout(string token);
    }
}
