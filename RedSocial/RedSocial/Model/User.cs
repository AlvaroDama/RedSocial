﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public string Avatar { get; set; }
    }
}
