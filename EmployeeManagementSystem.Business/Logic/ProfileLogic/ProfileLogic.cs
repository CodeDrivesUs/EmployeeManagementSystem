using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Repository.DataModels;
using AutoMapper;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Business.AutoMapper;
using System.Data.Entity;

namespace EmployeeManagementSystem.Business.Logic.ProfileLogic
{
    public class ProfileLogic:IProfileLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        public ProfileLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }

        public void CreatProfile( string userId)
        {
            _employeeManagementDbContext.applicantProfiles.Add(new ApplicantProfile { UserId = userId });
            _employeeManagementDbContext.SaveChanges();
        }

        public ApplicantProfileModel GetProfileByUserId(string UserId)
        {
            return ObjectMapper.Mapper.Map<ApplicantProfileModel>(_employeeManagementDbContext.applicantProfiles.Where(x => x.UserId == UserId).FirstOrDefault());
        }

        public void UpdateProfile(ApplicantProfileModel model) {

            var applicant = _employeeManagementDbContext.applicantProfiles.Find(model.Id);
            applicant.LastName = model.LastName;
            applicant.FirstName = model.FirstName;
            applicant.PhoneNumber = model.PhoneNumber;
            _employeeManagementDbContext.Entry(applicant).State = EntityState.Modified;
            _employeeManagementDbContext.SaveChanges();
        }

        public void addResume(ResumeModel model)
        {
            _employeeManagementDbContext.resumes.Add(ObjectMapper.Mapper.Map<Resume>(model));
            _employeeManagementDbContext.SaveChanges();
        }

        public List<ResumeModel> GetResumesByProfileId(int Id)
        {
            return ObjectMapper.Mapper.Map<List<ResumeModel>>(_employeeManagementDbContext.resumes.Where(x => x.ProfileId == Id).ToList());
        }

        public void removeResume( int Id)
        {
           var resume= _employeeManagementDbContext.resumes.Find(Id);
            _employeeManagementDbContext.resumes.Remove(resume);
            _employeeManagementDbContext.SaveChanges();
        }
    }
}
