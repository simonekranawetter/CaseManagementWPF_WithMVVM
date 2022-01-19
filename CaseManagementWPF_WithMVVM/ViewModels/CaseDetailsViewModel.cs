using CaseManagementWPF_WithMVVM.Commands;
using CaseManagementWPF_WithMVVM.Data;
using CaseManagementWPF_WithMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class CaseDetailsViewModel : ObservableObject
    {
        public int Id { get; set; }
        public CustomerViewModel Customer { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string CaseHandler { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        private CaseStatus _status;

        public CaseStatus Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }

        public ICommand SaveCaseCommand { get; set; }

        public CaseDetailsViewModel(CaseViewModel caseViewModel, object caseViewModel1)
        {
            Id = caseViewModel.Id;
            Customer = caseViewModel.Customer;
            Headline = caseViewModel.Headline;
            Description = caseViewModel.Description;
            CaseHandler = caseViewModel.CaseHandler;
            Created = caseViewModel.Created;
            Updated = caseViewModel.Updated;
            Status = caseViewModel.Status;

            SaveCaseCommand = new RelayCommand((p) =>
            {
                using (var context = new SqlContext())
                {
                    var myCase = context.Cases.Where(c => c.Id == Id).FirstOrDefault();
                    myCase.Status = Status;
                    context.SaveChanges();
                }
            });
        }

    }

  }
