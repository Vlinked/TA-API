using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TA_API.UtilityClass
{
    public class EmailModel
    {
        public string fromEmail { get; set; }
        public string toEmail { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        //public HttpPostedFileBase Attachment { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
