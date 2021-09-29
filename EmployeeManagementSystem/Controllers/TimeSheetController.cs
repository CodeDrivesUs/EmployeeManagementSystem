using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.TimeSheetLogic;
using EmployeeManagementSystem.Business.SharedModels;
using Microsoft.AspNet.Identity;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetLogic _timeSheetLogic;

        public TimeSheetController()
        {
            _timeSheetLogic = new TimeSheetLogic();
        }

        // GET: TimeSheet
        public ActionResult Index()
        {
            return View(_timeSheetLogic.GetTimeSheetsForAUser(User.Identity.GetUserId()));
        }

        public ActionResult Calendar(string userId)
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult CreateTimeSheet(TimeSheetModel model)
        {
            model.UserId = User.Identity.GetUserId();
            _timeSheetLogic.CreateTimeSheetLog(model);
            return RedirectToAction("Index");
        }

        public JsonResult GetMonthly() 
        {
            var results = _timeSheetLogic.GetMonthly(User.Identity.GetUserId());
            return Json( results,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetTotalDaily(string date) 
        {
            var results = _timeSheetLogic.GetTotalDay(date,User.Identity.GetUserId());
            return Json( results,JsonRequestBehavior.AllowGet);
        }
    }
}