using System;
using System.Collections.Generic;

namespace TA_API.EntityModels
{
    public partial class Users
    {
        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public int? RoleId { get; set; }
        public bool IsActive { get; set; }
        public string ProfileImg { get; set; }
        public string CreateDate { get; set; }
        public string LastModifiedDate { get; set; }
    }
}
