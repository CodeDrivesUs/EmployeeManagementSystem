using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.Logic.DepartmentLogic;
using EmployeeManagementSystem.Business.Logic.DevisionLogic;
using EmployeeManagementSystem.Business.AutoMapper;

namespace EmployeeManagementSystem.Business.Logic.EmployeeLogic
{
    public class EmployeeLogic :IEmployeeLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IDepartmentLogic _departmentLogic;
        private readonly IDevisionLogic _devisionLogic;

        public EmployeeLogic()
        {
            _departmentLogic = new DepartmentLogic.DepartmentLogic();
            _devisionLogic = new DevisionLogic.DevisionLogic();
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
            var list = ObjectMapper.Mapper.Map<List<EmployeeModel>>(model);
            foreach(var item in list)
            {
                try
                {
                    item.Devision = _devisionLogic.GetDevisionsById(item.DevisionId).DevisionName;

                }
                catch
                {
                    item.Devision = "Networking";
                }
                try
                {
                    item.Department = _departmentLogic.GetDepartmentById(item.DepartmentId).DepartmentName;

                }
                catch
                {
                    item.Department = "Information Technology";
                }
            }
            return list;
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
        public EmployeeModel GetEmployeesByEmail(string email)
        {
            var model = _employeeManagementDbContext.employees.FirstOrDefault(x => x.Email == email);
            return ObjectMapper.Mapper.Map<EmployeeModel>(model);
        }
        public int GetEmployeesIdByEmail(string email)
        {
            return GetEmployeesByEmail(email).Id;
        }
    }
}
