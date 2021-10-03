using EmployeeManagementSystem.Business.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Logic.DevisionLogic
{
   public  interface IDevisionLogic
    {
        void CreateDevision(DevisionModel model);
        List<DevisionModel> GetAllDevisions();
        void DeleteDevisions(DevisionModel model);
        DevisionModel GetDevisionsById(int Id);
        List<DevisionModel> GetAllDevisionsForADepartment(int department);
    }
}
