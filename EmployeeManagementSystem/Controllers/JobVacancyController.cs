using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.JobVacancyLogic;
using EmployeeManagementSystem.Business.Logic.DepartmentLogic;
using EmployeeManagementSystem.Business.Logic.DevisionLogic;
using EmployeeManagementSystem.Business.Logic.JobApplicationLogic;
using EmployeeManagementSystem.Business.Logic.ContractLogic;
using EmployeeManagementSystem.Business.Logic.ProfileLogic;
using EmployeeManagementSystem.Business.SharedModels;
using System.Net;

namespace EmployeeManagementSystem.Controllers
{
    public class JobVacancyController : Controller
    {
        // GET: JobVacancy
        private readonly IJobVacancyLogic _jobVacancyLogic;
        private readonly IDepartmentLogic _departmentLogic;
        private readonly IDevisionLogic _devisionLogic;
        private readonly IJobApplicationLogic _jobApplicationLogic;
        private readonly IContractLogic _contractLogic;
        private readonly IProfileLogic _profileLogic;

        public JobVacancyController()
        {
            _jobVacancyLogic = new JobVacancyLogic();
            _devisionLogic = new DevisionLogic();
            _departmentLogic = new DepartmentLogic();
            _jobApplicationLogic = new JobApplicationLogic();
            _contractLogic = new ContractLogic();
            _profileLogic = new ProfileLogic();
        }

        public ActionResult Index()
        {
            return View(_jobVacancyLogic.GetAllJobVacancies());
        }

        public ActionResult CreatVacancy()
        {
            return View(new JobVacancyModel { _allDepartments = _departmentLogic.GetAllDepartments(), _devisions = _devisionLogic.GetAllDevisions() });
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult CreatVacancy(JobVacancyModel model)
        {
            if (ModelState.IsValid)
            {
                int vacancyId = _jobVacancyLogic.CreateJobvacancy(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult JobApplications()
        {
            return View(_jobApplicationLogic.GetAllCompletedApplications());
        }
        
        public ActionResult Interviews()
        {
            return View(_jobApplicationLogic.GetAllInterInterviewViews());
        }

        public ActionResult JobApplication(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobApplication = _jobApplicationLogic.GetJobApplication((int)Id);
            if (jobApplication == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            jobApplication.JobVacancy = _jobVacancyLogic.GetJobVacancyById(jobApplication.VacancyId);
            return View(jobApplication);
        }

        public ActionResult Reject(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _jobApplicationLogic.RejectJobApplication((int)Id);
            return RedirectToAction("JobApplications");
        }

        public ActionResult ViewPDF(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobApplication = _jobApplicationLogic.GetJobApplication((int)Id);
            if (jobApplication == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(jobApplication);
        }

        public ActionResult ViewResults(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobApplication = _jobApplicationLogic.GetJobApplication((int)Id);
            if (jobApplication == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(jobApplication);
        }
        
        public ActionResult Interview(int? Interview)
        {
            if (Interview == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var JobInterview = _jobApplicationLogic.GetInterInterview((int)Interview);

            if (JobInterview == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            JobInterview.JobApplication = _jobApplicationLogic.GetJobApplication(JobInterview.JobApplicationId);
            JobInterview.ListContract = _contractLogic.GetAllContracts();
            return View( JobInterview);
        }

        [HttpPost]
        public ActionResult Interview(int Id,string Comment , string OutCome, int contract)
        {
            if (OutCome == "S")
            {
                _jobApplicationLogic.InterviewSuccess(Id, Comment);
                var fullcontract = _contractLogic.GetContractbyId(contract);
                var JobInterview = _jobApplicationLogic.GetInterInterview(Id);
                JobInterview.JobApplication = _jobApplicationLogic.GetJobApplication(JobInterview.JobApplicationId);
                var applicationcontract = new ApplicationContractModel();
                applicationcontract.Contract = fullcontract.File;
                applicationcontract.ContratId = contract;
                applicationcontract.ApplicationId = JobInterview.JobApplicationId;
                _contractLogic.AddContractToApplication(applicationcontract);
            }
            else
            {
                _jobApplicationLogic.InterviewNotSuccess(Id, Comment);
            }

            return View();
        }

            [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateInterview(InterviewModel model)
        {
            _jobApplicationLogic.CreateInterview(model);
            return RedirectToAction("JobApplications");
        }

    }
}