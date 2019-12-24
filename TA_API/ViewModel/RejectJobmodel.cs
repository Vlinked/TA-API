using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TA_API.ViewModel
{
    public class RejectJobmodel
    {
        public int JobApplId { get; set; }
        public bool IsAccepted { get; set; }
        public int? LastModifiedBy { get; set; }
        public string LastModifiedDate { get; set; }
    }
}
