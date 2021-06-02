using System.Collections.Generic;
using System.ComponentModel;

namespace Paylocity.ViewModels
{
    public class CostsPreviewViewModel
    {
        public CostsPreviewViewModel()
        {
            Employees = new List<EmployeeViewModel>();
            TotalCosts = 0M;
        }

        [DisplayName("Total Employees")]
        public List<EmployeeViewModel> Employees { get; set; }
        [DisplayName("Total Costs")]
        public decimal TotalCosts { get; set; }
    }
}