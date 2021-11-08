using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Business.SharedModels.Home;
using EmployeeManagementSystem.Business.SharedModels.JobVacancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.JobVacancyLogic
{
    public interface IJobVacancyLogic
    {
        int CreateJobvacancy(JobVacancyModel model);
        JobVacancyModel GetJobVacancyById(int Id);
        List<JobVacancyModel> GetJobVacancyByDepartmentId(int Id);
        List<JobVacancyModel> GetJobVacancyByDivisionId(int Id);
        List<JobVacancyByDivision> JobVacancyByDivisionsByDepartmentId(int Id);
        List<JobVacancyModel> GetAllJobVacancies();
        HomeIndex Initalize();
        List<JobVacancyModel> SearchJobVacancy(string keyWord);
    }
}
