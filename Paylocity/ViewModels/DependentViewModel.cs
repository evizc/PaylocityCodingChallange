using Paylocity.Models;

namespace Paylocity.ViewModels
{
    public class DependentViewModel : Person
    {
        public decimal CalculateDependentBenefitTotal()
        {
            if (FirstName.ToLower().StartsWith("a"))
            {
                this.Description = $"Dependent ({this.NameStartsWithADiscount}% 'A' name discount)";
                return this.DependentDiscount;
            }
            this.Description = "Dependent";
            return this.DependentCost;
        }
    }
}