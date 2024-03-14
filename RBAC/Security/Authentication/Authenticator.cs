﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Security.Authentication
{
    public interface Authenticator
    {
        bool execute(string username, string password);
    }
}
