using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class Question
    {
        public Question()
        {
            QustionAnswer = new HashSet<QustionAnswer>();
        }

        public long Id { get; set; }
        public long IdAlgorithem { get; set; }
        public string Question1 { get; set; }
        public int State { get; set; }
        public int QuestionOrder { get; set; }

        public virtual Algorithm IdAlgorithemNavigation { get; set; }
        public virtual ICollection<QustionAnswer> QustionAnswer { get; set; }
    }
}
