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
    internal class NewCaseViewModel : ObservableObject
    {
        public List<CustomerViewModel> Customers { get; set; }

        private CustomerViewModel _selectedCustomer;
        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; OnPropertyChanged(); }
        }

        private string _headline;
        public string Headline
        {
            get { return _headline; }
            set { _headline = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged();}
        }

        private string _caseHandler;
        public string CaseHandler
        {
            get { return _caseHandler; }
            set { _caseHandler = value; OnPropertyChanged(); }
        }

        private DateTime _created;
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; OnPropertyChanged();}
        }

        private DateTime _updated;
        public DateTime Updated
        {
            get { return _updated; }
            set { _updated = value; OnPropertyChanged();}
        }

        private CaseStatus _status;
        public CaseStatus Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged();}
        }

        public ICommand SaveNewCaseCommand { get; set; }
        public NewCaseViewModel()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
            Status = CaseStatus.Pending;

            using (var context = new SqlContext())
            {
                Customers= context.Customers
                    .Select(c => new CustomerViewModel(c))
                    .ToList();
            }
            SaveNewCaseCommand = new RelayCommand((p) =>
            {
                var newCase = new Case
                {
                    Headline = _headline,
                    Description = _description,
                    CaseHandler = _caseHandler,
                    Created = _created,
                    Updated = _updated,
                    Status = _status,
                    CustomerId = _selectedCustomer.Id
                };

                using(var context = new SqlContext())
                {
                    context.Cases.Add(newCase);
                    context.SaveChanges();
                }

                ResetForm();
            });
        }
        private void ResetForm()
        {
            SelectedCustomer = null;
            Headline = string.Empty;
            Description = string.Empty;
            CaseHandler = string.Empty;
            Created = DateTime.Now;
            Updated = DateTime.Now;
            Status = CaseStatus.Pending;
        }
    }
}
