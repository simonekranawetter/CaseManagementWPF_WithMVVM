using CaseManagementWPF_WithMVVM.Data;
using CaseManagementWPF_WithMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class CaseDetailsViewModel : ObservableObject
    {
        public List<CaseViewModelDetails> Cases { get; set; }
        private CaseViewModelDetails _selectedCase;
        public CaseViewModelDetails SelectedCase
        {
            get { return _selectedCase; }
            set { _selectedCase = value; OnPropertyChanged(); }
        }
        public CaseDetailsViewModel()
        {
           using (var context= new SqlContext())
            {
                Cases = context.Cases
                    .Include(c=> c.Customer)
                    .Select(c=> new CaseViewModelDetails(c))
                    .ToList();
            } 
        }
    }
  }
