using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TA_API.ViewModel
{
    public class CandidateProfileModel
    {
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
        public string Resumeattachment { get; set; }
        public bool FileExist { get; set; }
        public IFormFile FileUpload { get; set; }

    }
}
