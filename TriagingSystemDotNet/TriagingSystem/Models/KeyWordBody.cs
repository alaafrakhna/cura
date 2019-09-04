using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class KeyWordBody
    {
        public string KeyWord { get; set; }
        public long IdBodyPart { get; set; }
        public long Id { get; set; }

        public virtual BodyPart IdBodyPartNavigation { get; set; }
    }
}
