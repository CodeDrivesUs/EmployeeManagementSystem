using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.SharedModels;

namespace EmployeeManagementSystem.Business.AutoMapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Devision, DevisionModel>().ReverseMap();
                cfg.CreateMap<Department, DepartmentModel>().ReverseMap();
                cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
                cfg.CreateMap<Leave, LeaveModel>().ReverseMap();
                cfg.CreateMap<Salary, SalaryModel>().ReverseMap();
                cfg.CreateMap<JobVacancy, JobVacancyModel>().ReverseMap();
                cfg.CreateMap<TimeSheet, TimeSheetModel>().ReverseMap();
                cfg.CreateMap<JobApplication, JobApplicationModel>().ReverseMap();
                cfg.CreateMap<Interview, InterviewModel>().ReverseMap();
                cfg.CreateMap<ApplicantProfile, ApplicantProfileModel>().ReverseMap();
                cfg.CreateMap<Resume, ResumeModel>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
