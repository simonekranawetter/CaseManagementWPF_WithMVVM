using CaseManagementWPF_WithMVVM.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class CasesViewModel
    {
        public List<CaseViewModel> Cases { get; set; }

        public CasesViewModel()
        {
            using (var context = new SqlContext())
            {
                Cases = context.Cases
                    .Include(c => c.Customer)
                    .Select(c => new CaseViewModel(c))
                    .ToList();
            }
        }
    }
}
