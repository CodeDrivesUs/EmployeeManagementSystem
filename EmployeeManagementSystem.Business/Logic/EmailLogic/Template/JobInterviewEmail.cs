using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmployeeManagementSystem.Business.Logic.EmailLogic.Template
{
    public class JobInterviewEmail:BaseEmail.Email
    {
        private JobApplicationModel _jobApplication;
        private InterviewModel _interview;

        public JobInterviewEmail(InterviewModel interview, JobApplicationModel application) : base(application.Email, "Job application response ")
        {
            _jobApplication = application;
            _interview = interview;
        }

        public override string CreateEmailBody()
        {
            var body = GetEmailTemlateWithActionButtonAndHtmlContent("Go to Interview",CreateCallBackUrl(),CreateExtraBodyContent());
            body = body.Replace("{#Subject}", "Job application response");
            body = body.Replace("{#Greeting}", $"Dear {_jobApplication.FirstName}");
            return body.Replace("{#Body}", $"Thank you for your job application for: <strong>{_jobApplication.VacancyTittle}</strong>. " +
                $"Your job application was successfull you have been invited for an interview details are as followed ");
              
        }

        #region Private
        private string CreateCallBackUrl()
        {
            return $"{ConfigurationManager.AppSettings["BaseUrl"]}Room/Interview/?Interview={_interview.Id}";
        }

        private string CreateExtraBodyContent()
        {
            var result = new StringBuilder();
            result.Append($"<table><tr>");
            result.Append($"<td>");
            result.Append($"<h4><strong> Interview Details </strong></h4>");
            result.Append($"</td>");
            result.Append($"</tr>");
            result.Append($"<tr><td> <strong> Date </strong></td> <td> {_interview.Date.ToLongDateString()} </td> </tr>");
            result.Append($"<tr><td> <strong> Start Time </strong></td> <td> {_interview.start.ToLongTimeString()} </td > </tr>");
            result.Append($"<tr><td> <strong> End Time </strong></td> <td> {_interview.End.ToLongTimeString()} </td> </tr>");
            result.Append($"<tr><td> <strong> Location </strong></td> <td> Employee Management System </td>");
            result.Append($" </tr></table> ");
            return result.ToString();
        }
        #endregion
    }
}
