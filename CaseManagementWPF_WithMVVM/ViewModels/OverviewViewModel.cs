using CaseManagementWPF_WithMVVM.Data;
using CaseManagementWPF_WithMVVM.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class OverviewViewModel
    {
        public int Pending { get; set; }
        public int Ongoing { get; set; }
        public int Closed { get; set; }
        public List<CaseViewModel> Cases { get; set; }

        public OverviewViewModel()
        {
            using (var context = new SqlContext())
            {
                Pending = context.Cases.Where(c => c.Status == CaseStatus.Pending).Count();
                Ongoing = context.Cases.Where(c => c.Status == CaseStatus.Ongoing).Count();
                Closed = context.Cases.Where(c => c.Status == CaseStatus.Closed).Count();

                Cases = context.Cases
                    .Include(c => c.Customer)
                    .OrderBy(c => c.Created)
                    .Select(c => new CaseViewModel(c))
                    .Take(10)
                    .ToList();
            }
        }
    }
}
