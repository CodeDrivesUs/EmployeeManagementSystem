using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class ContractModel:PrimaryKey
    {
        public string Tittle { get; set; }
        public byte[] File { get; set; }
        public List<ContractModel> AllContracts { get; set; }
    }
}
