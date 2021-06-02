﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class Leave:PrimaryKey
    {
        public string leaveType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime appliedon { get; set; }
        public string reason { get; set; }
        public int EmployeeId { get; set; }
        public int statusId { get; set; }
    }
}
