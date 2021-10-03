using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class JobApplicationModel:PrimaryKey
    {
        public int VacancyId { get; set; }
        public string VacancyTittle { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string IdNumber { get; set; }
        public byte[] Cv { get; set; }
        public DateTime AppliedOn { get; set; }
        public int StatusId { get; set; }
        public JobVacancyModel JobVacancy { get; set; }
    }
}
