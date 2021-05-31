using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.DepartmentLogic
{
    public interface IDepartmentLogic
    {
        void CreateDepartment(DepartmentModel model);
        List<DepartmentModel> GetAllDepartments();
        void DeleteDepartment(DepartmentModel model);
        DepartmentModel GetDepartmentById(int Id);
    }
}
