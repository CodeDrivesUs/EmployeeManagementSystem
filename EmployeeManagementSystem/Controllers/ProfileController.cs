using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.SharedModels.Home;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Business.Logic.ProfileLogic;
using Microsoft.AspNet.Identity;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileLogic _profileLogic;
        public ProfileController()
        {
            _profileLogic = new  ProfileLogic();
        }
        // GET: Profile
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var profiel = _profileLogic.GetProfileByUserId(userId);
            return View( new MyProfile { profile = profiel, resumes = _profileLogic.GetResumesByProfileId(profiel.Id) } );
        }

        [HttpPost]
        public ActionResult UpdateProfile(ApplicantProfileModel model)
        {
            _profileLogic.UpdateProfile(model);
            return RedirectToAction("Index");
        }
    }
}