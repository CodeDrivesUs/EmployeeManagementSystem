using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.AutoMapper;
using EmployeeManagementSystem.Business.Logic.DepartmentLogic;

namespace EmployeeManagementSystem.Business.Logic.DevisionLogic
{
    public class DevisionLogic:IDevisionLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IDepartmentLogic _departmentLogic;

        public DevisionLogic()
        {
            _departmentLogic = new DepartmentLogic.DepartmentLogic();
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }
        public void CreateDevision(DevisionModel model)
        {
            _employeeManagementDbContext.devisions.Add(ObjectMapper.Mapper.Map<Devision>(model));
            _employeeManagementDbContext.SaveChanges();

        }

        public List<DevisionModel> GetAllDevisions()
        {
            
            var  _list= ObjectMapper.Mapper.Map<List<DevisionModel>>(_employeeManagementDbContext.devisions.ToList());
           foreach(var item in _list)
            {
                try
                {
                    item.DepartmentName = _departmentLogic.GetDepartmentById(item.DepartmentId).DepartmentName;

                }
                catch
                {
                    item.DepartmentName = "Information Technology";
                }
            }
            return _list;
        }

        public List<DevisionModel> GetAllDevisionsForADepartment(int department)
        {
            return ObjectMapper.Mapper.Map<List<DevisionModel>>(_employeeManagementDbContext.devisions.Where(x => x.DepartmentId == department).ToList());
        }

         public void DeleteDevisions(DevisionModel model)
        {
            _employeeManagementDbContext.devisions.Remove(_employeeManagementDbContext.devisions.Find(model.Id));
            _employeeManagementDbContext.SaveChanges();

        }
        public DevisionModel GetDevisionsById(int Id)
        {
            var model = _employeeManagementDbContext.devisions.FirstOrDefault(x => x.Id == Id);
            return ObjectMapper.Mapper.Map<DevisionModel>(model);
        }
    }
}
