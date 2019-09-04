using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class KeywordAlgorithem
    {
        public long IdAlgorithem { get; set; }
        public string Keyword { get; set; }
        public long Id { get; set; }

        public virtual Algorithm IdAlgorithemNavigation { get; set; }
    }
}
