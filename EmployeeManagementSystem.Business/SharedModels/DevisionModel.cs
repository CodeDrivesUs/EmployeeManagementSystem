using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class DevisionModel:PrimaryKey
    {
        public int DepartmentId { get; set; }
        public string DevisionName { get; set; }
        public string DepartmentName { get; set; }
        public List<DepartmentModel> _allDepartments { get; set; }
        public List<DevisionModel>  _devisions { get; set; }

    }
}
