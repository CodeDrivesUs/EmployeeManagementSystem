using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.SalaryLogic
{
    public interface ISalaryLogic
    {
        void CreateSalary(SalaryModel model);
        List<SalaryModel> GetAllSalaries();
    }
}
