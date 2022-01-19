using CaseManagementWPF_WithMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            _currentView = new OverviewViewModel();
            GoToCreateCustomerViewCommand = new RelayCommand((p) =>
            {
                CurrentView = new NewCustomerViewModel();
            });

            GoToCustomersViewCommand = new RelayCommand((p) =>
            {
                CurrentView = new CustomersViewModel();
            });
            GoToCreateCaseViewCommand = new RelayCommand((p) =>
            {
                CurrentView = new NewCaseViewModel();
            });
            GoToCasesViewCommand = new RelayCommand((p) =>
            {
                CurrentView = new CasesViewModel();
            });
            //GoToDetailedCaseViewCommand = new RelayCommand((p) =>
            //{
            //    CurrentView = new CaseDetailsViewModel();
            //});
            GoToOverviewViewCommand = new RelayCommand((p) =>
            {
                CurrentView = new OverviewViewModel();
            });
        }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public ICommand GoToCreateCustomerViewCommand { get; set; }
        public ICommand GoToCustomersViewCommand { get; set; }
        public ICommand GoToCreateCaseViewCommand { get; set; } 
        public ICommand GoToCasesViewCommand { get; set; }
        public ICommand GoToDetailedCaseViewCommand { get; set; }
        public ICommand GoToOverviewViewCommand { get; set; }
    }
}
