using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class UserRecord
    {
        public UserRecord()
        {
            QustionAnswer = new HashSet<QustionAnswer>();
        }

        public long Id { get; set; }
        public string InstructionCare { get; set; }
        public string Provider { get; set; }
        public int? FinalState { get; set; }
        public long UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Rating { get; set; }
        public long? AlgorithmId { get; set; }

        public virtual Algorithm Algorithm { get; set; }
        public virtual UserInfo User { get; set; }
        public virtual ICollection<QustionAnswer> QustionAnswer { get; set; }
    }
}
