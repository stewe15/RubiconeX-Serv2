﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RubiconeX_Serv.Core.Models
{
    public class UserInformatonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronumic { get; set; }
        public string AvatarUrl { get; set; }
        public DateTimeOffset Birtday { get; set; }
        public bool IsBoy { get; set; }
    }
}
