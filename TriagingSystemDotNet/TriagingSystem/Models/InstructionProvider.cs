using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class InstructionProvider
    {
        public long Id { get; set; }
        public int State { get; set; }
        public long AlgorithmId { get; set; }
        public string InstructionCare { get; set; }
        public string Provider { get; set; }

        public virtual Algorithm Algorithm { get; set; }
    }
}
