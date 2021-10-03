using EmployeeManagementSystem.Business.AutoMapper;
using EmployeeManagementSystem.Business.Enums;
using EmployeeManagementSystem.Business.Logic.EmailLogic.Template;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.Logic.JobVacancyLogic;

namespace EmployeeManagementSystem.Business.Logic.JobApplicationLogic
{
    public class JobApplicationLogic : IJobApplicationLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IJobVacancyLogic _jobVacancyLogic;

        public JobApplicationLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
            _jobVacancyLogic = new JobVacancyLogic.JobVacancyLogic();
        }

        public void CreateJobApplication(JobApplicationModel model)
        {
            model.AppliedOn = DateTime.Now;
            model.StatusId = (int)JobApplicationStatusEnums.Submitted;
            _employeeManagementDbContext.jobApplications.Add(ObjectMapper.Mapper.Map<JobApplication>(model));
            _employeeManagementDbContext.SaveChanges();
            var vacancy = _jobVacancyLogic.GetJobVacancyById(model.VacancyId);
            model.VacancyTittle = vacancy.Tittle;
            var email = new JobApplicationEmail(model);
            try { email.SendMail(); }
            catch { }
        }
        
        public List<JobApplicationModel> GetAllActiveApplications()
        {
            return ObjectMapper.Mapper.Map<List<JobApplicationModel>>(_employeeManagementDbContext.jobApplications.Where(x=>x.StatusId== (int)JobApplicationStatusEnums.Submitted).ToList());
        }

        public JobApplicationModel GetJobApplication(int Id)
        {
            return ObjectMapper.Mapper.Map<JobApplicationModel>(_employeeManagementDbContext.jobApplications.Find(Id));
        }
    }
}
