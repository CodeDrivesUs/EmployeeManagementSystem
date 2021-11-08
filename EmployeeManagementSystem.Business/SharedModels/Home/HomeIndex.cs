using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels.Home
{
    public class HomeIndex
    {
        public List<ListDepartment>  listDepartments { get; set; }
        public List<JobVacancyModel> SearchedJobs { get; set; }
        public string searchtext { get; set; }
    }
}
