using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.ProfileLogic
{
    public interface IProfileLogic
    {
        void CreatProfile(string userId);
        ApplicantProfileModel GetProfileByUserId(string UserId);
        void UpdateProfile(ApplicantProfileModel model);
        void addResume(ResumeModel model);
        List<ResumeModel> GetResumesByProfileId(int Id);
        void removeResume(int Id);
        ResumeModel GetResumebyId(int Id);

    }
}
