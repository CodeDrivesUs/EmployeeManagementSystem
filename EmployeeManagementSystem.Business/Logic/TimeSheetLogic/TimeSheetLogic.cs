using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using AutoMapper;
using EmployeeManagementSystem.Business.AutoMapper;

namespace EmployeeManagementSystem.Business.Logic.TimeSheetLogic
{
    public class TimeSheetLogic:ITimeSheetLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;

        public TimeSheetLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
        }

        public void CreateTimeSheetLog( TimeSheetModel model)
        {
            model.DateCreated = DateTime.Now;
            model.Start = Convert.ToDateTime($"{model.Date.ToShortDateString()}  {model.Start.ToShortTimeString()}");
            model.End = Convert.ToDateTime($"{model.Date.ToShortDateString()}  {model.End.ToShortTimeString()}");
            _employeeManagementDbContext.timeSheets.Add(ObjectMapper.Mapper.Map<TimeSheet>(model));
            _employeeManagementDbContext.SaveChanges();
        }

        public List<TimeSheetModel> GetTimeSheetsForAUser(string userId)
        {
            return ObjectMapper.Mapper.Map<List<TimeSheetModel>>(_employeeManagementDbContext.timeSheets.Where(x => x.UserId == userId).ToList());
        }

        public void DeleteById(int Id)
        {
            var timesheet = _employeeManagementDbContext.timeSheets.Find(Id);
            _employeeManagementDbContext.timeSheets.Remove(timesheet);
            _employeeManagementDbContext.SaveChanges();
        }
        
        public TimeSheetModel GetById(int Id)
        {
            return ObjectMapper.Mapper.Map<TimeSheetModel>( _employeeManagementDbContext.timeSheets.Find(Id));
           
        }


        public List<MontlyTimeSheetCalendar> GetMonthly(string userId)
        {
           var returnedList = new List<MontlyTimeSheetCalendar>();
           var currentdate = DateTime.Now;
            int datesubtracter = 0;
            for(int i = 1; i <= currentdate.Day; i++)
            {
                double duration = 0;
                var computedDate = currentdate.AddDays(datesubtracter);
                var timesheets = GetTimeSheetsForADay(computedDate, userId);
                foreach(var  item in timesheets)
                {
                    TimeSpan diff = (item.End - item.Start);
                    duration += diff.TotalHours;
                }
                string day= computedDate.Day.ToString();
                string month = computedDate.Month.ToString();
                    
                if (computedDate.Day < 10)
                {
                    day = "0" +computedDate.Day;
                }
                if (computedDate.Month < 10)
                {
                    month = "0" +computedDate.Month;
                }
                if (duration < 8)
                {
                    returnedList.Add(new MontlyTimeSheetCalendar { IsComplete = false, date = $"{computedDate.Year}-{month}-{day}" });
                }
                else
                {
                    returnedList.Add(new MontlyTimeSheetCalendar { IsComplete = true, date = $"{computedDate.Year}-{month}-{day}" });

                }
                datesubtracter--;

            }
            return returnedList;
        }


        public MontlyTimeSheetCalendar GetTotalDay(string date,string userId)
        {
            var actualDate = Convert.ToDateTime(date);
            var timesheets = GetTimeSheetsForADay(actualDate, userId);
            double duration = 0;
            var model = new MontlyTimeSheetCalendar();
            foreach (var item in timesheets)
            {
                TimeSpan diff = (item.End - item.Start);
                duration += diff.TotalHours;
            }
            string day = actualDate.Day.ToString();

            if (actualDate.Day < 10)
            {
                day = "0" + actualDate.Day;
            }
            if (duration < 8)
            {
              model=  new MontlyTimeSheetCalendar { IsComplete = false, date = $"{actualDate.Year}-{actualDate.Month}-{day}" };
            }
            else
            {
               model= new MontlyTimeSheetCalendar { IsComplete = true, date = $"{actualDate.Year}-{actualDate.Month}-{day}" };
            }
            return model;
        }

        public List<TimeSheetModel> GetTimeSheetsForADay(DateTime date, string userId)
        {
            var  list =ObjectMapper.Mapper.Map<List<TimeSheetModel>>(_employeeManagementDbContext.timeSheets.Where(x => x.UserId==userId).ToList());
            return list.Where(x => x.Start.Date == date.Date).ToList();
        }


    }
}
