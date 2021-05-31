using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class EmployeeModel:PrimaryKey
    {
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int DevisionId { get; set; }
        public string Devision { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public byte[] EmployeeImage { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<DepartmentModel> _allDepartments { get; set; }
        public List<DevisionModel> _devisions { get; set; }
    }
}
