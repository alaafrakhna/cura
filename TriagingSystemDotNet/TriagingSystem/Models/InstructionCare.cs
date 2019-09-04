using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class InstructionCare
    {
        public long Id { get; set; }
        public int State { get; set; }
        public long AlgorithmId { get; set; }
        public string InstructionCare1 { get; set; }

        public virtual Algorithm Algorithm { get; set; }
    }
}
