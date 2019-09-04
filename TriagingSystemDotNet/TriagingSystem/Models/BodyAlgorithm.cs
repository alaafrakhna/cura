using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class BodyAlgorithm
    {
        public long IdAlgorithm { get; set; }
        public long IdBodyPart { get; set; }

        public virtual Algorithm IdAlgorithmNavigation { get; set; }
        public virtual BodyPart IdBodyPartNavigation { get; set; }
    }
}
