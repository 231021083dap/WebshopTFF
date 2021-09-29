﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Helpers;

namespace WebshopAPI.Responses
{
    public class LoginResponse
    {
        public int Id { get; set; }        
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}