namespace Paylocity.Models
{
    public class Benefits
    {
        public decimal DependentCost => 500M;
        public decimal BenefitCost => 1000M;
        public int NameStartsWithADiscount => 10;
        public decimal DependentDiscount => DependentCost - (DependentCost * NameStartsWithADiscount / 100);
        public decimal EmployeeDiscount => BenefitCost - (BenefitCost * NameStartsWithADiscount / 100);
        public decimal PaycheckAmount => 2000M;
        public int TotalPaychecks => 26;
    }
}