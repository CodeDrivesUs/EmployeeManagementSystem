using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.ContractLogic
{
    public interface IContractLogic
    {
        void AddContract(ContractModel model);
        List<ContractModel> GetAllContracts();
        ContractModel GetContractbyId(int Id);
        void AddContractToApplication(ApplicationContractModel model);
        List<ApplicationContractModel> GetAllWaitingToBeSigned(string email);
        ApplicationContractModel GetApplicationContractByApplicationId(int AppId);
    }
}
