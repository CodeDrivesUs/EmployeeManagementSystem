using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.AutoMapper;
using EmployeeManagementSystem.Business.Logic.EmailLogic.Template;
using EmployeeManagementSystem.Business.Logic.EmployeeLogic;
using EmployeeManagementSystem.Business.Logic.DevisionLogic;
using EmployeeManagementSystem.Business.Enums;
using EmployeeManagementSystem.Business.SharedModels.JobVacancy;

namespace EmployeeManagementSystem.Business.Logic.JobVacancyLogic
{
    public class JobVacancyLogic : IJobVacancyLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IDevisionLogic _devisionLogic;

        public JobVacancyLogic()
        {
            _devisionLogic = new DevisionLogic.DevisionLogic();
            _employeeManagementDbContext = new EmployeeManagementDbContext();
            _employeeLogic = new EmployeeLogic.EmployeeLogic();
        }

        public int CreateJobvacancy(JobVacancyModel model)
        {
            model.CreationDate = DateTime.Now;
            var dbmodel = ObjectMapper.Mapper.Map<JobVacancy>(model);
            _employeeManagementDbContext.jobVacancies.Add(dbmodel);
            _employeeManagementDbContext.SaveChanges();
            if (model.Type == (int)JobVacancyTypeEnums.Internal)
            {
                foreach (var item in _employeeLogic.GetAllEmployees())
                {
                    var email = new EmployeeJobVacancyEmail(item, model);
                    try { email.SendMail(); }
                    catch { }
                }
            }
            return dbmodel.Id;
        }

        public List<JobVacancyModel> GetJobVacancyByDepartmentId(int Id)
        {
            return ObjectMapper.Mapper.Map<List<JobVacancyModel>>(_employeeManagementDbContext.jobVacancies.Where(x=>x.DepartmentId==Id).ToList());
        }
        
        public List<JobVacancyModel> GetJobVacancyByDivisionId(int Id)
        {
            return ObjectMapper.Mapper.Map<List<JobVacancyModel>>(_employeeManagementDbContext.jobVacancies.Where(x=>x.DevisionId==Id).ToList());
        }

        public List<JobVacancyByDivision> JobVacancyByDivisionsByDepartmentId(int Id)
        {
            var returnedList = new List<JobVacancyByDivision>();
            foreach(var devision in _devisionLogic.GetAllDevisionsForADepartment(Id))
            {
                returnedList.Add(new JobVacancyByDivision
                {
                    Devision = devision,
                    Jobs = GetJobVacancyByDivisionId(devision.Id)
                }); ;
            }
          return returnedList;
        }

        public JobVacancyModel GetJobVacancyById(int Id)
        {
            return ObjectMapper.Mapper.Map<JobVacancyModel>(_employeeManagementDbContext.jobVacancies.Find(Id));
        }

    }
}
