using CaseManagementWPF_WithMVVM.Models;

namespace CaseManagementWPF_WithMVVM.ViewModels
{
    internal class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public CustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = $"{customer.FirstName} {customer.LastName}";
            Email = customer.Email;
            Phone = customer.Phone;
            Mobile = customer.Mobile;
            Address = $"{customer.Address} \n{customer.ZipCode} {customer.City}";
            Country = customer.Country;
        }
    }
}
