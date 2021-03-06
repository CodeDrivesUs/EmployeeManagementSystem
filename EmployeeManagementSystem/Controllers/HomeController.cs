using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.JobVacancyLogic;
using EmployeeManagementSystem.Business.Logic.DepartmentLogic;
using EmployeeManagementSystem.Business.Logic.JobApplicationLogic;
using EmployeeManagementSystem.Business.Logic.EmployeeLogic;
using EmployeeManagementSystem.Business.SharedModels;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobVacancyLogic _jobVacancyLogic;
        private readonly IDepartmentLogic _departmentLogic;
        private readonly IJobApplicationLogic _jobApplicationLogic;
        private readonly IEmployeeLogic _employeeLogic;

        public HomeController()
        {
            _jobApplicationLogic = new JobApplicationLogic();
            _departmentLogic = new DepartmentLogic();
            _jobVacancyLogic = new JobVacancyLogic();
            _employeeLogic = new EmployeeLogic();
        }

        public ActionResult Index()
        {
            var employee = _employeeLogic.GetEmployeesByEmail(User.Identity.Name.ToString());

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard","Admin");
            }
            
            if (User.IsInRole("Hr"))
            {
                return View("view");
            }
           
            if (Request.IsAuthenticated)
            {
                if (employee == null)
                {
                    return RedirectToAction("Index", "Profile");
                }
                return RedirectToAction("Dashboard", "Employee");
            }
            return View(_jobVacancyLogic.Initalize());
        }

        public ActionResult Success()
        {
            return View("About");
        }

        public ActionResult VacabcyDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vacancy = _jobVacancyLogic.GetJobVacancyById((int)id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }
        public ActionResult VacabcyForDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = _departmentLogic.GetDepartmentById((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
          
            return View(_jobVacancyLogic.JobVacancyByDivisionsByDepartmentId(department.Id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreatJobApplication(JobApplicationModel jobApplicationModel, HttpPostedFileBase cvFile)
        {
            if (ModelState.IsValid)
            {
                if (cvFile != null)
                {
                    int filelength = cvFile.ContentLength;
                    byte[] Myfile = new byte[filelength];
                    cvFile.InputStream.Read(Myfile, 0, filelength);
                    jobApplicationModel.Cv = Myfile;
                  _jobApplicationLogic.CreateJobApplication(jobApplicationModel);

                    return RedirectToAction("Success");
                }
            }
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}