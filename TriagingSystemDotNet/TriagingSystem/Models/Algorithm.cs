using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class Algorithm
    {
        public Algorithm()
        {
            BodyAlgorithm = new HashSet<BodyAlgorithm>();
            InstructionCare = new HashSet<InstructionCare>();
            KeywordAlgorithem = new HashSet<KeywordAlgorithem>();
            Question = new HashSet<Question>();
            UserRecord = new HashSet<UserRecord>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstStep { get; set; }
        public int InjeryOrillness { get; set; }

        public virtual ICollection<BodyAlgorithm> BodyAlgorithm { get; set; }
        public virtual ICollection<InstructionCare> InstructionCare { get; set; }
        public virtual ICollection<KeywordAlgorithem> KeywordAlgorithem { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<UserRecord> UserRecord { get; set; }
    }
}
