using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class DepartmentModel:PrimaryKey
    {
        public string DepartmentName { get; set; }
        public List<DepartmentModel> _allDepartments { get; set; }

    }
}
