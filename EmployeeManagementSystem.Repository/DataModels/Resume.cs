using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class Resume:PrimaryKey
    {
        public int ProfileId { get; set; }
        public DateTime date { get; set; }
        public byte[] CV { get; set; }
    }
}
