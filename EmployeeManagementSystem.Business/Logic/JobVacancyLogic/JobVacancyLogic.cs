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
using EmployeeManagementSystem.Business.Logic.EmailLogic.Template;
using EmployeeManagementSystem.Business.Logic.EmployeeLogic;

namespace EmployeeManagementSystem.Business.Logic.JobVacancyLogic
{
    public class JobVacancyLogic : IJobVacancyLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IEmployeeLogic _employeeLogic;
        public JobVacancyLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
            _employeeLogic = new EmployeeLogic.EmployeeLogic();
        }

        public void CreateJobvacancy(JobVacancyModel model)
        {
            _employeeManagementDbContext.jobVacancies.Add(ObjectMapper.Mapper.Map<JobVacancy>(model));
            _employeeManagementDbContext.SaveChanges();
            foreach (var item in _employeeLogic.GetAllEmployees())
            {
                var email = new EmployeeJobVacancyEmail(item,model);
                try { email.SendMail(); }
                catch{ }
            }
        }
    }
}
