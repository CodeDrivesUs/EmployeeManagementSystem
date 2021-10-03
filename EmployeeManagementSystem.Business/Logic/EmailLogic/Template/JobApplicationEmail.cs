using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.EmailLogic.Template
{
    public class JobApplicationEmail:BaseEmail.Email
    {
        private JobApplicationModel _jobApplication;
        public JobApplicationEmail(JobApplicationModel application) :base(application.Email,"Job Application Was Submitted Successfully")
        {
            _jobApplication = application;
        }

        public override string CreateEmailBody()
        {
            var body = GetEmailTemplate() ;
            body = body.Replace("{#Subject}", "Job Application Was Submitted Successfully");
            body = body.Replace("{#Greeting}", $"Dear {_jobApplication.FirstName}");
            return body.Replace("{#Body}", $"This email serves to inform you that you job application for: <strong>{_jobApplication.VacancyTittle}</strong> has been recieved.");
        }
    }
}
