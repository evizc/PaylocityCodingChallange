using Paylocity.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Paylocity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new EmployeeViewModel());
        }

        public ActionResult PreviewCosts(List<EmployeeViewModel> employees)
        {
            var model = new CostsPreviewViewModel();

            try
            {
                foreach (EmployeeViewModel employee in employees)
                {
                    if (string.IsNullOrEmpty(employee.FirstName)) continue;

                    decimal benefitCosts = employee.CalculateEmployeeBenefitTotal();

                    foreach (var dependent in employee.Dependents)
                    {
                        if (string.IsNullOrEmpty(dependent.FirstName)) continue;
                        benefitCosts += dependent.CalculateDependentBenefitTotal();
                    }

                    employee.Salary = (employee.PaycheckAmount * employee.TotalPaychecks) - benefitCosts;
                    model.Employees.Add(employee);
                    model.TotalCosts += employee.Salary;
                }

                return PartialView("_PreviewCosts", model);
            }
            catch (Exception ex)
            {
                return PartialView("_Error", ex);
            }
        }
    }
}