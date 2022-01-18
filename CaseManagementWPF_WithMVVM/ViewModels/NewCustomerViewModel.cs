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
    internal class NewCustomerViewModel : ObservableObject
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged();}
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged();}
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged();}
        }
        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; OnPropertyChanged();}
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged();}
        }
        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; OnPropertyChanged();}
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged();}
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; OnPropertyChanged();}
        }

        public ICommand SaveCustomerCommand { get; set; }

        public NewCustomerViewModel()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _email = string.Empty;
            _phone = string.Empty;
            _mobile = string.Empty;
            _address = string.Empty;
            _zipCode = string.Empty;
            _city = string.Empty;
            _country = string.Empty;

            SaveCustomerCommand = new RelayCommand((p) =>
            {
                var customer = new Customer
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    Email = _email,
                    Phone = _phone,
                    Mobile = _mobile,
                    Address = _address,
                    ZipCode = _zipCode,
                    City = _city,
                    Country = _country
                };
                using (var context = new SqlContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }

                ResetForm();
            });
        }
        private void ResetForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Mobile = string.Empty;
            Address = string.Empty;
            ZipCode = string.Empty;
            City = string.Empty;
            Country = string.Empty;
        }
    }
}
