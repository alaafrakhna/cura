using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class TrustedContact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int ContactOrder { get; set; }
        public long IdUser { get; set; }

        public virtual UserInfo IdUserNavigation { get; set; }
    }
}
