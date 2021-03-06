using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.LeaveLogic
{
    public interface ILeaveLogic
    {
        void CreateLeave(LeaveModel model);
        List<LeaveModel> GetAllLeaves();
        List<LeaveModel> GetAllLeavesByEmployeeId(int Id);
        List<LeaveModel> GetAllSubmittedLeaves();
        List<LeaveModel> GetAllApprovedLeaves();
        List<LeaveModel> GetAllDeclinedLeaves();
        LeaveModel GetLeaveById(int Id);
        void ProcessLeave(LeaveModel model);
    }
}
