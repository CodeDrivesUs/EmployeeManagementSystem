using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Business.Logic.ContractLogic;


namespace EmployeeManagementSystem.Controllers
{
    public class HRController : Controller
    {
        private readonly IContractLogic _contractLogic;
        // GET: HR

        public HRController()
        {
            _contractLogic = new ContractLogic();
        }
        public ActionResult Contract()
        {
            return View(new ContractModel { AllContracts= _contractLogic.GetAllContracts() });
        }
        
        [HttpPost]
        public ActionResult Contract(string Tittle,  HttpPostedFileBase contract)
        {
            if (contract != null)
            {
                int filelength = contract.ContentLength;
                byte[] Myfile = new byte[filelength];
                contract.InputStream.Read(Myfile, 0, filelength);
                _contractLogic.AddContract(new ContractModel { Tittle = Tittle, File = Myfile });
                return RedirectToAction("Contract");
            }
            return RedirectToAction("Contract");
        }
    }
}