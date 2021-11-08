using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class ApplicationContractModel:PrimaryKey
    {
        public int ApplicationId { get; set; }
        public int ProfileId { get; set; }
        public int ContratId { get; set; }
        public string UserSignedAt { get; set; }
        public byte[] Contract { get; set; }
        public int StatusId { get; set; }
        public ContractModel  ContractModel { get; set; }
    }
}
