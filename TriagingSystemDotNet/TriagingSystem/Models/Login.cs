using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriagingSystem.Models
{
    public class Login
    {
        public Login()
        {
            //TrustedContact = new HashSet<TrustedContact>();
            //UserRecord = new HashSet<UserRecord>();
        }

        public string Password { get; set; }
        public string Email { get; set; }
    }
}
