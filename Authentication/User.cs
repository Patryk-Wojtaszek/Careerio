﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerio.Authentication
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public byte RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
