using System;
using System.Collections.Generic;

namespace TriagingSystem.Models
{
    public partial class QustionAnswer
    {
        public long IdRecord { get; set; }
        public string Answer { get; set; }
        public long IdQuestion { get; set; }
        public long Id { get; set; }
        public string AnswerApproved { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
        public virtual UserRecord IdRecordNavigation { get; set; }
    }
}
