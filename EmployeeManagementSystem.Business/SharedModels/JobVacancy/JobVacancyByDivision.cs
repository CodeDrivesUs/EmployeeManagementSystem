using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels.JobVacancy
{
    public class JobVacancyByDivision
    {
        public DevisionModel Devision { get; set; }
        public List<JobVacancyModel> Jobs { get; set; }
    }
}
