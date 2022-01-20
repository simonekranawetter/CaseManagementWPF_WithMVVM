using CaseManagementWPF_WithMVVM.Data;
using System.Collections.Generic;
using System.Linq;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class CustomersViewModel
    {
        public List<CustomerViewModel> Customers { get; set; }
        public CustomersViewModel()
        {
            using (var context = new SqlContext())
            {
                Customers = context.Customers
                    .Select(u => new CustomerViewModel(u))
                    .ToList();
            }
        }
    }
}
