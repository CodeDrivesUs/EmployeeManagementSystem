using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.SharedModels.Home;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Business.Logic.ProfileLogic;
using Microsoft.AspNet.Identity;
using EmployeeManagementSystem.Business.Logic.JobVacancyLogic;
using EmployeeManagementSystem.Business.Logic.JobApplicationLogic;
using EmployeeManagementSystem.Business.Logic.ContractLogic;
using System.Net;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileLogic _profileLogic;
        private readonly IJobVacancyLogic _jobVacancyLogic;
        private readonly IJobApplicationLogic _jobApplicationLogic;
        private readonly IContractLogic _contractLogic;

        public ProfileController()
        {
            _profileLogic = new  ProfileLogic();
            _jobVacancyLogic = new JobVacancyLogic();
            _jobApplicationLogic = new JobApplicationLogic();
            _contractLogic = new ContractLogic();
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
        
        
        [HttpPost]
        public ActionResult addCV(ResumeModel model, HttpPostedFileBase upload)
        {

            if (upload != null)
            {
                int filelength = upload.ContentLength;
                byte[] Myfile = new byte[filelength];
                upload.InputStream.Read(Myfile, 0, filelength);
                model.CV = Myfile;
                model.date = DateTime.Now;
                model.FileName = upload.FileName;
                _profileLogic.addResume(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteResume( int Id)
        {
            _profileLogic.removeResume(Id);
            return RedirectToAction("Index");
        }

        public ActionResult ViewmyCv(int Id)
        {
            return View(_profileLogic.GetResumebyId(Id));
        }

        public ActionResult SearchJobs( string search)
        {
            var result = _jobVacancyLogic.Initalize();
            return View(result);
        }
        
        [HttpPost]
        public ActionResult Search( string search)
        {
            var result = _jobVacancyLogic.Initalize();
            if (!string.IsNullOrEmpty(search))
            {
                result.searchtext = search;
                result.SearchedJobs = _jobVacancyLogic.SearchJobVacancy(search);
            }
            return View("SearchJobs", result);
        }

        public ActionResult JobVacancyDetails(int Id)
        {
            string userId = User.Identity.GetUserId();
            var profiel = _profileLogic.GetProfileByUserId(userId);
            var result = new MyProfile { profile = profiel, resumes = _profileLogic.GetResumesByProfileId(profiel.Id) };
            var job = _jobVacancyLogic.GetJobVacancyById(Id);
            job.Profile = result;
            return View(job);
        }

        public ActionResult AwaitingAssessment()
        {
            string UserEmail = User.Identity.Name;
            return View(_jobApplicationLogic.GetAllActiveApplications().Where(x=>x.Email==UserEmail).ToList());
        }
        public ActionResult Assessment(int? Id)
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
        
        [HttpPost]
        public ActionResult UploadResults(int Id, HttpPostedFileBase results)
        {
          
            var jobApplication = _jobApplicationLogic.GetJobApplication(Id);
            if (jobApplication == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (results != null)
            {
                int filelength = results.ContentLength;
                byte[] Myfile = new byte[filelength];
                results.InputStream.Read(Myfile, 0, filelength);
                jobApplication.TestResponse = Myfile;
                _jobApplicationLogic.UploadTestResults(jobApplication);
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreatJobApplication(JobApplicationModel jobApplicationModel, int CvId)
        {
            if (ModelState.IsValid)
            {
                jobApplicationModel.Cv = _profileLogic.GetResumebyId(CvId).CV;
               _jobApplicationLogic.CreateJobApplication(jobApplicationModel);
                    return RedirectToAction("Success");
            }
            return View();
        }

        public ActionResult MyContracts()
        {
            return View(_contractLogic.GetAllWaitingToBeSigned(User.Identity.Name));
        }

    }
}