﻿using System;
using System.Collections.Generic;

namespace TA_API.EntityModels
{
    public partial class JobApplied
    {
        public int JobApplId { get; set; }
        public int Userid { get; set; }
        public int JobId { get; set; }
        public string Designation { get; set; }
        public int ProfiledId { get; set; }
        public string CreateDate { get; set; }
    }
}