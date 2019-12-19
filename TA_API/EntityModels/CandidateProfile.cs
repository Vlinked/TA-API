using System;
using System.Collections.Generic;

namespace TA_API.EntityModels
{
    public partial class CandidateProfile
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Designation { get; set; }
        public string DesiredLocation { get; set; }
        public string CurrentCompany { get; set; }
        public int? Experience { get; set; }
        public int NoticePeriod { get; set; }
        public int? CurrentCtc { get; set; }
        public int? ExpectedCtc { get; set; }
        public string Skills { get; set; }
        public int Userid { get; set; }
        public string CreateDate { get; set; }
        public string Resumeattachmen { get; set; }
        public bool? LastModifiedBy { get; set; }
        public string LastModifiedDate { get; set; }

        public virtual Users User { get; set; }
    }
}
