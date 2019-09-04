using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            TrustedContact = new HashSet<TrustedContact>();
            UserRecord = new HashSet<UserRecord>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? DoB { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<TrustedContact> TrustedContact { get; set; }
        public virtual ICollection<UserRecord> UserRecord { get; set; }
    }
}
