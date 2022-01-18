using CaseManagementWPF_WithMVVM.Data;
using CaseManagementWPF_WithMVVM.Commands;
using CaseManagementWPF_WithMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
