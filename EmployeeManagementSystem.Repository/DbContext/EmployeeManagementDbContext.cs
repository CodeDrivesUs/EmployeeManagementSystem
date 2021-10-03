using System;
using System.Data.Entity;
using System.Linq;
using EmployeeManagementSystem.Repository.DataModels;

namespace EmployeeManagementSystem.Repository.DbContext
{
    public class EmployeeManagementDbContext : System.Data.Entity.DbContext
    {
        
        public EmployeeManagementDbContext()
            : base("name=EmployeeManagementDbContext")
        {
        }
        public DbSet<Employee>  employees { get; set; }
        public DbSet<Devision>  devisions { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Leave>  leaves { get; set; }
        public DbSet<Salary> salaries  { get; set; }
        public DbSet<JobVacancy> jobVacancies  { get; set; }
        public DbSet<JobApplication> jobApplications   { get; set; }
        public DbSet<Attachment> attachments    { get; set; }
        public DbSet<TimeSheet>  timeSheets  { get; set; }
        public DbSet<Interview>  interviews   { get; set; }

    }


}