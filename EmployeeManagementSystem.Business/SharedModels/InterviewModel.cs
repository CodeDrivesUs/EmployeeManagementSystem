using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class InterviewModel:PrimaryKey
    {
        public DateTime Date { get; set; }
        public DateTime start { get; set; }
        public DateTime End { get; set; }
        public int JobApplicationId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime DateCreated { get; set; }
        public string InterviewrPeerId { get; set; }
        public JobApplicationModel JobApplication { get; set; }
        public List<ContractModel> ListContract { get; set; }
        public string Comment { get; set; }
        public int statusId { get; set; }
    }
}
