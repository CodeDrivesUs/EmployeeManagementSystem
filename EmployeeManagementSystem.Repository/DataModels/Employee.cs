using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class Employee:PrimaryKey
    {
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int DepartmentId { get; set; }
        public int DevisionId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public byte[] EmployeeImage { get; set; }
        public DateTime CreatedOn { get; set; }
		
	}
}
