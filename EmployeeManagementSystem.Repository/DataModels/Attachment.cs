using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.DataModels
{
    public class Attachment:PrimaryKey
    {
        public byte[] file { get; set; }
        public DateTime DateAdded { get; set; }
        public int JoApplicationId { get; set; }
    }
}
