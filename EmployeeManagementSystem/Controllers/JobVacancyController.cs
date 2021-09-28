using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.JobVacancyLogic;
using EmployeeManagementSystem.Business.Logic.DepartmentLogic;
using EmployeeManagementSystem.Business.Logic.DevisionLogic;
using EmployeeManagementSystem.Business.SharedModels;

namespace EmployeeManagementSystem.Controllers
{
    public class JobVacancyController : Controller
    {
        // GET: JobVacancy
        private readonly IJobVacancyLogic _jobVacancyLogic;
        private readonly IDepartmentLogic _departmentLogic;
        private readonly IDevisionLogic _devisionLogic;


        public JobVacancyController()
        {
            _jobVacancyLogic = new JobVacancyLogic();
            _devisionLogic = new DevisionLogic();
            _departmentLogic = new DepartmentLogic();
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
                _jobVacancyLogic.CreateJobvacancy(model);
                return RedirectToAction("ViewLeave");
            }
            return View();
        }
    }
}