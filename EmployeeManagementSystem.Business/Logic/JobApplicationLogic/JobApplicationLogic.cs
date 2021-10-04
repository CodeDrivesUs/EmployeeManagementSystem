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

        public void RejectJobApplication(int Id)
        {
            var jobapplication = _employeeManagementDbContext.jobApplications.Find(Id);
            jobapplication.StatusId = (int)JobApplicationStatusEnums.Rejected;
            _employeeManagementDbContext.SaveChanges();
            var vacancy = _jobVacancyLogic.GetJobVacancyById(jobapplication.VacancyId);
            var jobapplicationmodel = ObjectMapper.Mapper.Map<JobApplicationModel>(jobapplication);
            jobapplicationmodel.VacancyTittle = vacancy.Tittle;
            var email = new JobRejectionEmail(jobapplicationmodel);
            try { email.SendMail(); }
            catch { }
        }

        public JobApplicationModel GetJobApplication(int Id)
        {
            return ObjectMapper.Mapper.Map<JobApplicationModel>(_employeeManagementDbContext.jobApplications.Find(Id));
        }

        public void CreateInterview(InterviewModel model)
        {
            model.DateCreated = DateTime.Now;
            model.RoomId = new Guid();
            var interview = ObjectMapper.Mapper.Map<Interview>(model);
            _employeeManagementDbContext.interviews.Add(interview);
            var jobapplication = _employeeManagementDbContext.jobApplications.Find(model.JobApplicationId);
            jobapplication.StatusId = (int)JobApplicationStatusEnums.AwaitingInterView;
            _employeeManagementDbContext.SaveChanges();
            var jobModel = ObjectMapper.Mapper.Map<JobApplicationModel>(jobapplication);
            jobModel.VacancyTittle = _jobVacancyLogic.GetJobVacancyById(jobapplication.VacancyId).Tittle;
            model.Id = interview.Id;
            var email = new JobInterviewEmail(model,jobModel);
            try { email.SendMail(); }
            catch { }
        }

        public InterviewModel GetInterInterview(int Id)
        {
            return ObjectMapper.Mapper.Map<InterviewModel>(_employeeManagementDbContext.interviews.Find(Id));
        }

        public void SetInterviwerPeerId(string peerId, int Id)
        {
            var interview = _employeeManagementDbContext.interviews.Find(Id);
            interview.InterviewrPeerId = peerId;
            _employeeManagementDbContext.SaveChanges();
        }

        }
}
