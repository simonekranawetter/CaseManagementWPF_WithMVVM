using CaseManagementWPF_WithMVVM.Commands;
using CaseManagementWPF_WithMVVM.Models;
using CaseManagementWPF_WithMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class CaseViewModel
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string CaseHandler { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public CaseStatus Status { get; set; }
        public CustomerViewModel Customer { get; set; }

        public ICommand ViewDetailsCommand { get; set; }

        public CaseViewModel(Case myCase)
        {
            Id = myCase.Id;
            Headline = myCase.Headline;
            Description = myCase.Description;
            CaseHandler = myCase.CaseHandler;
            Created = myCase.Created;
            Updated = myCase.Updated;
            Status = myCase.Status;
            Customer = new CustomerViewModel(myCase.Customer);

        }
    }
}
