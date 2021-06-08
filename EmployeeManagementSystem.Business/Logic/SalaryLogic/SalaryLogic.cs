using EmployeeManagementSystem.Business.AutoMapper;
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

        public SalaryLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }
        public void CreateSalary(SalaryModel model)
        {
            model.CreatedOn = DateTime.Now;
            _employeeManagementDbContext.salaries.Add(ObjectMapper.Mapper.Map<Salary>(model));
            _employeeManagementDbContext.SaveChanges();
        }
    }
}
