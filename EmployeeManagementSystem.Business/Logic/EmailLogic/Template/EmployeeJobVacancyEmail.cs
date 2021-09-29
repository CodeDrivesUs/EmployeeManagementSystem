using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.EmailLogic.Template
{
    public class EmployeeJobVacancyEmail: BaseEmail.Email
    {
        private EmployeeModel _employee;
        private JobVacancyModel _jobVacancy;

        public EmployeeJobVacancyEmail(EmployeeModel employee, JobVacancyModel jobVacancy) : base(employee.Email, "New Job opening")
        {
            _employee = employee;
            _jobVacancy = jobVacancy;
        }

        public override string CreateEmailBody()
        {
            var body =  GetEmailTemlateWithActionButtonAndHtmlContent("Apply", CreateCallBackUrl(),_jobVacancy.Description);
            body = body.Replace("{#Subject}", $"New Job opening for:{_jobVacancy.Tittle}");
            body = body.Replace("{#Greeting}", $"Dear {_employee.EmployeeName}");
            return body.Replace("{#Body}", "This email serves to inform you that there is a new Job opening at work, if your are interested click the apply button bellow ");
        }



        #region Private
        private string CreateCallBackUrl()
        {
            return $"/Landlord/myflats";
        }
        #endregion
    }
}
