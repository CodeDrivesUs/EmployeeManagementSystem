using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public  class ResumeModel
    {
        public int ProfileId { get; set; }
        public DateTime date { get; set; }
        public byte[] CV { get; set; }
    }
}
