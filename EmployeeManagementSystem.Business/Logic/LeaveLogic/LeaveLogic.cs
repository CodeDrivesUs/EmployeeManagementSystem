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

namespace EmployeeManagementSystem.Business.Logic.LeaveLogic
{
    public class LeaveLogic:ILeaveLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
      
        public LeaveLogic()
        {           
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
    }
}
