using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class Devision:PrimaryKey
    {
        public int DepartmentId { get; set; }
        public string DevisionName { get; set; }
    }
}
