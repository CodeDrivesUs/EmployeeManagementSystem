using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.DepartmentLogic;
using EmployeeManagementSystem.Business.Logic.DevisionLogic;
using EmployeeManagementSystem.Business.Logic.EmployeeLogic;
using EmployeeManagementSystem.Business.Logic.LeaveLogic;
using EmployeeManagementSystem.Business.SharedModels;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IDepartmentLogic _departmentLogic;
        private readonly IDevisionLogic _devisionLogic;
        private readonly IEmployeeLogic _employeeLogic;
        private ILeaveLogic _leaveLogic;

        public AdminController()
        {
            _leaveLogic = new LeaveLogic();
            _employeeLogic = new EmployeeLogic();
            _devisionLogic = new DevisionLogic();
            _departmentLogic = new DepartmentLogic();
        }
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Department()
        {
            return View(new DepartmentModel {_allDepartments= _departmentLogic.GetAllDepartments() });
        } 
        [HttpPost]
        public ActionResult Department(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                _departmentLogic.CreateDepartment(model);
                return RedirectToAction("Department");
            }
            return View(model);
        }   
        public ActionResult DeleteDepartment(int? id)
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
            _departmentLogic.DeleteDepartment(department);
            return RedirectToAction("Department");

        }
        public ActionResult Division()
        {
            return View(new DevisionModel { _allDepartments= _departmentLogic.GetAllDepartments(), _devisions=_devisionLogic.GetAllDevisions() });
        }
        [HttpPost]
        public ActionResult Division(DevisionModel model)
        {
            if (ModelState.IsValid)
            {
                _devisionLogic.CreateDevision(model);
                return RedirectToAction("Division");

            }
            return RedirectToAction("Division");
        }
        public ActionResult DeleteDivision(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var devision = _devisionLogic.GetDevisionsById((int)id);
            if (devision == null)
            {
                return HttpNotFound();
            }
            _devisionLogic.DeleteDevisions(devision);
            return RedirectToAction("Division");

        }
        public ActionResult Employee()
        {
            return View(new EmployeeModel { _allDepartments=_departmentLogic.GetAllDepartments(), _devisions=_devisionLogic.GetAllDevisions() });
        }
        [HttpPost]
        public ActionResult Employee(EmployeeModel model, HttpPostedFileBase EmplyeeImage)
        {
            //if (ModelState.IsValid)
            //{
                if (EmplyeeImage != null)
                {
                    int filelength = EmplyeeImage.ContentLength;
                    byte[] Myfile = new byte[filelength];
                    EmplyeeImage.InputStream.Read(Myfile, 0, filelength);
                    model.EmployeeImage = Myfile;
                    model.CreatedOn = DateTime.Now;
                    _employeeLogic.CreateEmployee(model);
                    return RedirectToAction("ViewEmployee");
                }
         //   }
                return RedirectToAction("Employee");
        }

        public ActionResult ViewEmployee()
        {
            return View(_employeeLogic.GetAllEmployees());
        }
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = _employeeLogic.GetEmployeesById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            _employeeLogic.DeleteEmployees(employee);
            return RedirectToAction("ViewEmployee");
        }
        public ActionResult ViewLeave()
        {
            return View(_leaveLogic.GetAllLeaves());
        }
        public ActionResult SubmittedLeave()
        {
            return View("ViewLeave", _leaveLogic.GetAllSubmittedLeaves());
        }
        public ActionResult ApprovedLeave()
        {
            return View("ViewLeave", _leaveLogic.GetAllApprovedLeaves());
        }
        public ActionResult DeclinedLeave()
        {
            return View("ViewLeave", _leaveLogic.GetAllDeclinedLeaves());
        }
    }
}