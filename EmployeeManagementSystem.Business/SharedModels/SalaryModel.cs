using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.SharedModels
{
    public class SalaryModel:PrimaryKey
    {
        public int DisionId { get; set; }
        public string DivisionName { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HouseRent { get; set; }
        public decimal PensionFund { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal UIF { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal FuelAllowance { get; set; }
        public decimal PhoneBillAllowance { get; set; }
        public decimal TravelAllowance { get; set; }
        public decimal OtherAllowance { get; set; }
        public decimal TaxDeductions { get; set; }
        public decimal OtherDeductions { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<DevisionModel> _devisions { get; set; }
        public List<EmployeeModel>  _employees { get; set; }

        public decimal calcMedAid()
        { /* for this instance the company pays the mandatory 15%of you salary as a medical aid benefit*/
            return BasicSalary * 0.15m;
        }
        public decimal calcPensionfund()
        {  /* rate is 5.25 pension fund deduction*/
            Decimal rate = 0.0525m;
            return BasicSalary * rate;
        }

        public decimal calcGrossSalary()
        {
            return PhoneBillAllowance + TravelAllowance + BasicSalary - (TravelAllowance * 0.2m) - calcPensionfund();
        }
        public decimal calcTax()
        {
            decimal Tax = 0m;
            decimal rebate = 15714m; /* rebate is the discount after tax is calculated age is used to work this out ,
                                      at this case for now all employee are under 65 years  */

            if (BasicSalary <= 87300)
            {
                return Tax;
            }
            else if ((BasicSalary > 87300) && (BasicSalary <= 216200))
            {
                Tax = ((calcGrossSalary() * 0.18m) - rebate);
                return Tax;
            }

            else if ((BasicSalary > 216200) && (BasicSalary <= 337800))
            {
                return Tax = (38916 + (0.26m * (calcGrossSalary() - 216200)) - rebate);
            }

            else if ((BasicSalary > 337800) && (BasicSalary <= 467500))
            {
                return Tax = (70532 + (0.31m * (calcGrossSalary() - 337800)) - rebate);
            }

            else if ((BasicSalary > 467500) && (BasicSalary <= 613600))
            {
                return Tax = (110739 + (0.36m * (calcGrossSalary() - 467500)) - rebate);
            }

            else if ((BasicSalary > 613600) && (BasicSalary <= 782200))
            {
                return Tax = (163335 + (0.39m * (calcGrossSalary() - 613600)) - rebate);
            }

            else if ((BasicSalary > 782200) && (BasicSalary <= 1626600))
            {
                return Tax = (229089 + (0.41m * (calcGrossSalary() - 782200)) - rebate);
            }

            return Tax;
        }
        public decimal calcDeduction()
        {
            /*this method is an addition not having much use, totalAmount dedcted from the actual basic salary*/
            return calcUIF() + calcPensionfund() + calcTax();
        }
        public decimal calcSalaryIncludingTax()
        {
            return calcGrossSalary() - calcTax();
        }
        public decimal calcUIF()
        {/*UIF is deducted on the grossSalary after tax deduction */
            return calcSalaryIncludingTax() * 0.01m;
        }
        public decimal calcNetSalary()
        {
            return calcSalaryIncludingTax() - calcUIF();
        }
    }
}
