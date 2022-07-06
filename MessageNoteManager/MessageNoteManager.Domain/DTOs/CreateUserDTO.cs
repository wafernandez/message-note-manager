﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Domain
{
    public class CreateUserDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Enums.UserType UserType { get; set; }
    }
}
