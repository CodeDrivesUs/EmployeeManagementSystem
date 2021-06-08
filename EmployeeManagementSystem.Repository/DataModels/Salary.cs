using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class Salary:PrimaryKey
    {
        public int DisionId { get; set; }
        public int EmployeeId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HouseRent { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal FuelAllowance { get; set; }
        public decimal PhoneBillAllowance { get; set; }
        public decimal OtherAllowance { get; set; }
        public decimal TaxDeductions { get; set; }
        public decimal OtherDeductions { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
