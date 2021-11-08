using EmployeeManagementSystem.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Business.SharedModels;
using EmployeeManagementSystem.Business.Enums;
using EmployeeManagementSystem.Repository.DataModels;
using EmployeeManagementSystem.Business.AutoMapper;
using EmployeeManagementSystem.Business.Logic.JobApplicationLogic;

namespace EmployeeManagementSystem.Business.Logic.ContractLogic
{
    public class ContractLogic : IContractLogic
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        private readonly IJobApplicationLogic _jobApplicationLogic;

        public ContractLogic()
        {
            _employeeManagementDbContext = new EmployeeManagementDbContext();
            _jobApplicationLogic = new JobApplicationLogic.JobApplicationLogic();
        }

        public void AddContract(ContractModel model)
        {
            _employeeManagementDbContext.contracts.Add(ObjectMapper.Mapper.Map<Contract>(model));
            _employeeManagementDbContext.SaveChanges();
        }

        public List<ContractModel> GetAllContracts()
        {
            return ObjectMapper.Mapper.Map<List<ContractModel>>(_employeeManagementDbContext.contracts.ToList());
        }

        public ContractModel GetContractbyId(int Id)
        {
            return ObjectMapper.Mapper.Map<ContractModel>(_employeeManagementDbContext.contracts.Find(Id));
        }

        public void AddContractToApplication(ApplicationContractModel model)
        {
            model.StatusId = (int)ContractEnums.SentToUser;
            _employeeManagementDbContext.applicationContracts.Add(ObjectMapper.Mapper.Map<ApplicationContract>(model));
            _employeeManagementDbContext.SaveChanges();
        }

        public List<ApplicationContractModel> GetAllWaitingToBeSigned(string email)
        {
            var list = new List<ApplicationContractModel>();

            var interviews = _jobApplicationLogic.GetAllInterInterviewViews().Where(x=>x.JobApplication.Email==email && x.statusId==(int)InterviewOutComeEnums.Success).ToList();
            foreach(var interview in interviews)
            {
                list.Add(GetApplicationContractByApplicationId(interview.JobApplication.Id));
            }
            return list;
        }

        public ApplicationContractModel GetApplicationContractByApplicationId(int AppId)
        {
            var contract = ObjectMapper.Mapper.Map<ApplicationContractModel>(_employeeManagementDbContext.applicationContracts.Where(x => x.ApplicationId == AppId).FirstOrDefault());
            contract.ContractModel = GetContractbyId(contract.ContratId);
            return contract;
        }

    }
}
