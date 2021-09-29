using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.TimeSheetLogic
{
    public interface ITimeSheetLogic
    {
        void CreateTimeSheetLog(TimeSheetModel model);
        List<TimeSheetModel> GetTimeSheetsForAUser(string userId);
        List<TimeSheetModel> GetTimeSheetsForADay(DateTime date, string userId);
        List<MontlyTimeSheetCalendar> GetMonthly(string userId);
        MontlyTimeSheetCalendar GetTotalDay(string date, string userId);
    }
}
