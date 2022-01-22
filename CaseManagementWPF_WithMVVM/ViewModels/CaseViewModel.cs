using CaseManagementWPF_WithMVVM.Commands;
using CaseManagementWPF_WithMVVM.Data;
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
    internal class CaseViewModelDetails : ObservableObject
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string CaseHandler { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        private CaseStatus _status;
        public CaseStatus Status
        {
            get { return _status; }
            set 
            { 
                _status = value;
                Updated = DateTime.Now;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Updated));

                using (var context = new SqlContext())
                {
                    var myCase = context.Cases
                        .Where(c => c.Id == Id)
                        .First();
                    myCase.Status = _status;
                    myCase.Updated = Updated;
                    context.SaveChanges();
                }
            }
        }
        public CustomerViewModel Customer { get; set; }
        public ICommand command { get; set; }
        public CaseViewModelDetails(Case myCase)
        {
            Id = myCase.Id;
            Headline = myCase.Headline;
            Description= myCase.Description;
            CaseHandler = myCase.CaseHandler;
            Created = myCase.Created;
            Updated = myCase.Updated;
            Status = myCase.Status;
            Customer = new CustomerViewModel(myCase.Customer);
        }
    } 
}
