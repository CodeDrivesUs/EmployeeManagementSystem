using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.Logic.JobApplicationLogic;

namespace EmployeeManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly IJobApplicationLogic _jobApplicationLogic;
        public RoomController()
        {
            _jobApplicationLogic = new JobApplicationLogic();
        }

        // GET: Room
        public ActionResult Index(int? Interview)
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
            return View(JobInterview);
        }
        
        public ActionResult Sender()
        {
            return View();
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
            return View("Sender",JobInterview);
        }

        public JsonResult GetInterview(int Id)
        {
            return Json(_jobApplicationLogic.GetInterInterview(Id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult SetPeerId(int Id,string peerId)
        {
            _jobApplicationLogic.SetInterviwerPeerId(peerId, Id);
            return Json(new {success= true }, JsonRequestBehavior.AllowGet);
        }

       

    }
}