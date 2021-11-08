using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class Contract:PrimaryKey
    {
        public string Tittle { get; set; }
        public byte[] File { get; set; }
    }
}
