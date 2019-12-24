using System;
using System.Collections.Generic;

namespace TA_API.EntityModels
{
    public partial class NewJob
    {
        public int JobId { get; set; }
        public int DesgnId { get; set; }
        public string SkillSet { get; set; }
        public int Experience { get; set; }
        public int Positions { get; set; }
        public decimal Ctc { get; set; }
        public int Userid { get; set; }
        public string JobType { get; set; }
        public string Qualification { get; set; }
        public string NoticePeriod { get; set; }
        public string JobDesc { get; set; }
        public bool IsCompleted { get; set; }
        public string CreatedDate { get; set; }
        public string LastmodifiedDate { get; set; }
    }
}
