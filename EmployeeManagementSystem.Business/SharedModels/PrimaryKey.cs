﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class PrimaryKey
    {
        [Key]
        public int Id { get; set; }
    }
}
