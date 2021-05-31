using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.AutoMapper;

namespace EmployeeManagementSystem.Business.Logic.EmployeeLogic
{
    public class EmployeeLogic :IEmployeeLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        public EmployeeLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }
        public void CreateEmployee(EmployeeModel model)
        {
            _employeeManagementDbContext.employees.Add(ObjectMapper.Mapper.Map<Employee>(model));
            _employeeManagementDbContext.SaveChanges();
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            var model = _employeeManagementDbContext.employees.ToList();
            return ObjectMapper.Mapper.Map<List<EmployeeModel>>(model);
        }
        public void DeleteEmployees(EmployeeModel model)
        {
            _employeeManagementDbContext.employees.Remove(_employeeManagementDbContext.employees.Find(model.Id));
            _employeeManagementDbContext.SaveChanges();

        }
        public EmployeeModel GetEmployeesById(int Id)
        {
            var model = _employeeManagementDbContext.employees.FirstOrDefault(x => x.Id == Id);
            return ObjectMapper.Mapper.Map<EmployeeModel>(model);
        }
    }
}
