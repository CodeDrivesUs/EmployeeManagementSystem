using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using AutoMapper;
using EmployeeManagementSystem.Business.AutoMapper;

namespace EmployeeManagementSystem.Business.Logic.JobVacancyLogic
{
    public class JobVacancyLogic : IJobVacancyLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;

        public JobVacancyLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }

        public void CreateJobvacancy(JobVacancyModel model)
        {
            _employeeManagementDbContext.jobVacancies.Add(ObjectMapper.Mapper.Map<JobVacancy>(model));
            _employeeManagementDbContext.SaveChanges();
        }
    }
}
