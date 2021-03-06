using EmployeeManagementSystem.Business.AutoMapper;
using EmployeeManagementSystem.Business.Logic.EmployeeLogic;
using EmployeeManagementSystem.Business.Logic.DevisionLogic;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.SalaryLogic
{
    public class SalaryLogic:ISalaryLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IDevisionLogic _devisionLogic;

        public SalaryLogic()
        {
            _devisionLogic = new DevisionLogic.DevisionLogic();
            _employeeLogic = new EmployeeLogic.EmployeeLogic();
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }

        public void CreateSalary(SalaryModel model)
        {
            model.CreatedOn = DateTime.Now;

            model.MedicalAllowance = model.calcMedAid();
            model.PensionFund = model.calcPensionfund();
            model.UIF = model.calcUIF();
            model.GrossSalary = model.calcGrossSalary();
            model.TotalDeductions = model.calcDeduction();
            model.TaxDeductions = model.calcTax();
            model.NetSalary = model.calcNetSalary();
            _employeeManagementDbContext.salaries.Add(ObjectMapper.Mapper.Map<Salary>(model));
            _employeeManagementDbContext.SaveChanges();
        }

        public List<SalaryModel> GetAllSalaries()
        {
            var _list = ObjectMapper.Mapper.Map<List<SalaryModel>>(_employeeManagementDbContext.salaries.ToList());
            foreach ( var item in _list){
                try
                {
                   item.EmployeeName = _employeeLogic.GetEmployeesById(item.EmployeeId).EmployeeName;

                }
                catch
                {
                    item.EmployeeName = "Mvuselelo";
                }
                try
                {
                    item.DivisionName = _devisionLogic.GetDevisionsById(item.DisionId).DevisionName;

                }
                catch
                {
                    item.DivisionName = "Networking";
                }
            }
            return _list;
        }
        public List<SalaryModel> GetAllSalariesByEmployeeId(int Id)
        {
            return GetAllSalaries().Where(x => x.EmployeeId == Id).ToList();
        }
    }
}
