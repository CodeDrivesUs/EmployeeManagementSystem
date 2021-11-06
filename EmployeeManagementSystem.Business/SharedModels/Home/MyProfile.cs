using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels.Home
{
    public class MyProfile
    {
        public ApplicantProfileModel  profile { get; set; }
        public List<ResumeModel>  resumes { get; set; }
    }
}
