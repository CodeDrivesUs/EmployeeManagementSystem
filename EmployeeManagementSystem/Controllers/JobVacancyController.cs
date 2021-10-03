using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.JobVacancyLogic;
using EmployeeManagementSystem.Business.Logic.DepartmentLogic;
using EmployeeManagementSystem.Business.Logic.DevisionLogic;
using EmployeeManagementSystem.Business.Logic.JobApplicationLogic;
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


        public JobVacancyController()
        {
            _jobVacancyLogic = new JobVacancyLogic();
            _devisionLogic = new DevisionLogic();
            _departmentLogic = new DepartmentLogic();
            _jobApplicationLogic = new JobApplicationLogic();
        }

        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction("VacabcyDetails", "Home", new { id = vacancyId });
            }
            return View();
        }

        public ActionResult JobApplications()
        {
            return View(_jobApplicationLogic.GetAllActiveApplications());
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

    }
}