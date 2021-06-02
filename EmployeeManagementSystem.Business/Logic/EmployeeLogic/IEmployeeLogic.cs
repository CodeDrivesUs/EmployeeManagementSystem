using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.EmployeeLogic
{
    public  interface IEmployeeLogic
    {
        void CreateEmployee(EmployeeModel model);
        List<EmployeeModel> GetAllEmployees();
        void DeleteEmployees(EmployeeModel model);
        EmployeeModel GetEmployeesById(int Id);
        EmployeeModel GetEmployeesByEmail(string email);
        int GetEmployeesIdByEmail(string email);
    }
}
