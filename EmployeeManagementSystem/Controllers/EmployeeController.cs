using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.EmployeeLogic;
using EmployeeManagementSystem.Business.Logic.LeaveLogic;
using EmployeeManagementSystem.Business.Logic.SalaryLogic;
using EmployeeManagementSystem.Business.SharedModels;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeLogic _employeeLogic;
        private ILeaveLogic _leaveLogic;
        private ISalaryLogic _salaryLogic;
        public EmployeeController()
        {
            _salaryLogic = new  SalaryLogic();
            _employeeLogic = new EmployeeLogic();
            _leaveLogic = new LeaveLogic();
        }
        // GET: Employee
        public ActionResult Dashboard()
        {
            return View();
        }  
        public ActionResult ViewLeave()
        {
            return View(_leaveLogic.GetAllLeavesByEmployeeId(GetEmployeeId()));
        }  
        public ActionResult ApplyLeave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ApplyLeave(LeaveModel model)
        {
            if (ModelState.IsValid)
            {
                model.appliedon = DateTime.Now;
                model.EmployeeId = GetEmployeeId();
                _leaveLogic.CreateLeave(model);
                return RedirectToAction("ViewLeave");
            }
            return View(model);
        }


        public ActionResult ViewSalary()
        {
            return View(_salaryLogic.GetAllSalariesByEmployeeId(GetEmployeeId()));
        }
        private int GetEmployeeId()
        {
            string username = User.Identity.Name.ToString();
            return _employeeLogic.GetEmployeesIdByEmail(username);

        }
    }
}