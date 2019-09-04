using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class BodyPart
    {
        public BodyPart()
        {
            BodyAlgorithm = new HashSet<BodyAlgorithm>();
            KeyWordBody = new HashSet<KeyWordBody>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BodyAlgorithm> BodyAlgorithm { get; set; }
        public virtual ICollection<KeyWordBody> KeyWordBody { get; set; }
    }
}
