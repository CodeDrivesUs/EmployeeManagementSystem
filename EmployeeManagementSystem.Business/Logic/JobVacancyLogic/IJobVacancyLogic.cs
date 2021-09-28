using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.JobVacancyLogic
{
    public interface IJobVacancyLogic
    {
        void CreateJobvacancy(JobVacancyModel model);
    }
}
