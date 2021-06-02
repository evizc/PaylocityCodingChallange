using Paylocity.Models;
using System.Collections.Generic;
using System.Linq;

namespace Paylocity.ViewModels
{
    public class EmployeeViewModel : Person
    {
        public EmployeeViewModel()
        {
            Dependents = new List<DependentViewModel>();
        }

        public decimal Salary { get; set; }
        public decimal SalaryBeforeDeductions => this.PaycheckAmount * this.TotalPaychecks;
        public decimal SalaryAfterDeductions => this.SalaryBeforeDeductions - this.TotalBenefitsCost;
        public decimal TotalBenefitsCost => this.Dependents.Sum(x => x.CalculateDependentBenefitTotal()) + this.CalculateEmployeeBenefitTotal();
        public List<DependentViewModel> Dependents { get; set; }

        public decimal CalculateEmployeeBenefitTotal()
        {
            if (FirstName.ToLower().StartsWith("a"))
            {
                this.Description = $"Employee ({this.NameStartsWithADiscount}% 'A' name discount)";
                return this.EmployeeDiscount;
            }
            this.Description = "Employee";
            return this.BenefitCost;
        }
    }
}