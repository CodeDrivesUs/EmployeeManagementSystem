using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.AutoMapper;

namespace EmployeeManagementSystem.Business.Logic.DevisionLogic
{
    public class DevisionLogic:IDevisionLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        public DevisionLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }
        public void CreateDevision(DevisionModel model)
        {
            _employeeManagementDbContext.devisions.Add(ObjectMapper.Mapper.Map<Devision>(model));
            _employeeManagementDbContext.SaveChanges();

        }

        public List<DevisionModel> GetAllDevisions()
        {
            var model = _employeeManagementDbContext.devisions.ToList();
            return ObjectMapper.Mapper.Map<List<DevisionModel>>(model);
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
