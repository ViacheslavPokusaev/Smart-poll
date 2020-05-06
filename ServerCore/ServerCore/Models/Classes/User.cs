using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Models.Classes
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
