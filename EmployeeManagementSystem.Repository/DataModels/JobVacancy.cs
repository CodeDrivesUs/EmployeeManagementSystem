using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class JobVacancy:PrimaryKey
    {
        public int DepartmentId { get; set; }
        public int DevisionId { get; set; }
        public string Tittle { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int MaximumNumberOfApplications { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
