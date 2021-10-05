using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.JobApplicationLogic
{
    public interface IJobApplicationLogic
    {
        void CreateJobApplication(JobApplicationModel model);
        List<JobApplicationModel> GetAllActiveApplications();
        JobApplicationModel GetJobApplication(int Id);
        void RejectJobApplication(int Id);
        void CreateInterview(InterviewModel model);
        void SetInterviwerPeerId(string peerId, int Id);
        InterviewModel GetInterInterview(int Id);
        List<InterviewModel> GetAllInterInterviewViews();
    }
}
