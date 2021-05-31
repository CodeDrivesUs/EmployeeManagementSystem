using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Repository.DbContext;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.SharedModels;
using AutoMapper;
using EmployeeManagementSystem.Business.AutoMapper;

namespace EmployeeManagementSystem.Business.Logic.DepartmentLogic
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        public DepartmentLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }

        public void CreateDepartment(DepartmentModel model)
        {
            _employeeManagementDbContext.departments.Add(ObjectMapper.Mapper.Map<Department>(model));
            _employeeManagementDbContext.SaveChanges();

        }
        public List<DepartmentModel> GetAllDepartments()
        {
            var  model = _employeeManagementDbContext.departments.ToList();
            return ObjectMapper.Mapper.Map<List<DepartmentModel>>(model);
        }
        public void DeleteDepartment(DepartmentModel model)
        {
            _employeeManagementDbContext.departments.Remove(_employeeManagementDbContext.departments.Find(model.Id));
            _employeeManagementDbContext.SaveChanges();

        }
        public DepartmentModel GetDepartmentById(int Id)
        {
            var model = _employeeManagementDbContext.departments.FirstOrDefault(x=>x.Id==Id);
            return ObjectMapper.Mapper.Map<DepartmentModel>(model);
        }
    }
}
