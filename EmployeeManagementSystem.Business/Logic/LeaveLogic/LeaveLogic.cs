using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.AutoMapper;
using EmployeeManagementSystem.Business.Enums;
using EmployeeManagementSystem.Business.Logic.EmployeeLogic;
using System.Data.Entity;

namespace EmployeeManagementSystem.Business.Logic.LeaveLogic
{
    public class LeaveLogic:ILeaveLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IEmployeeLogic _employee;
      
        public LeaveLogic()
        {
            _employee = new EmployeeLogic.EmployeeLogic();
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }
        public void CreateLeave(LeaveModel model)
        {
            model.statusId = (int)LeavestatusEnum.Submitted;
            _employeeManagementDbContext.leaves.Add(ObjectMapper.Mapper.Map<Leave>(model));
            _employeeManagementDbContext.SaveChanges();
        }

        public List<LeaveModel> GetAllLeaves()
        {
            var model = _employeeManagementDbContext.leaves.ToList();
            return ObjectMapper.Mapper.Map<List<LeaveModel>>(model);
        }
        public List<LeaveModel> GetAllSubmittedLeaves()
        {
            return GetAllLeaves().Where(x => x.statusId == (int)LeavestatusEnum.Submitted).ToList();
        } 
        public List<LeaveModel> GetAllApprovedLeaves()
        {
            return GetAllLeaves().Where(x => x.statusId == (int)LeavestatusEnum.Approved).ToList();
        }     
        public List<LeaveModel> GetAllDeclinedLeaves()
        {
            return GetAllLeaves().Where(x => x.statusId == (int)LeavestatusEnum.Declined).ToList();
        }
      

        public List<LeaveModel> GetAllLeavesByEmployeeId(int Id)
        {
            return GetAllLeaves().Where(x => x.EmployeeId == Id).ToList();
        }
        public LeaveModel GetLeaveById(int Id)
        {
            var model = _employeeManagementDbContext.leaves.FirstOrDefault(x => x.Id == Id);
            var  leave = ObjectMapper.Mapper.Map<LeaveModel>(model);
            leave.EmployeeName = _employee.GetEmployeesById(leave.EmployeeId).EmployeeName;
            return leave;
        }
        public void ProcessLeave(LeaveModel model)
        {
            var leave = _employeeManagementDbContext.leaves.FirstOrDefault(x => x.Id == model.Id);
            leave.statusId = model.statusId;
            _employeeManagementDbContext.Entry(leave).State = EntityState.Modified;
            _employeeManagementDbContext.SaveChanges();
        }
       
    }
}
