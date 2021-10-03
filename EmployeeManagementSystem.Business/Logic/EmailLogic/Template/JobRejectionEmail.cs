using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.EmailLogic.Template
{
    public class JobRejectionEmail:BaseEmail.Email
    {
        private JobApplicationModel _jobApplication;
        public JobRejectionEmail(JobApplicationModel application) : base(application.Email, "Job application response ")
        {
            _jobApplication = application;
        }

        public override string CreateEmailBody()
        {
            var body = GetEmailTemplate();
            body = body.Replace("{#Subject}", "Job application response");
            body = body.Replace("{#Greeting}", $"Dear {_jobApplication.FirstName}");
            return body.Replace("{#Body}", $"Thank you for your job application for: <strong>{_jobApplication.VacancyTittle}</strong>.  " +
                $"Unfortunately, you have been unsuccessful in your application, but we will keep your CV in our database and we will notify you when new positions that meet" +
                $"your experience become available.");
        }
    }
}
