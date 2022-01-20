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
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public CustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = $"{customer.FirstName}{customer.LastName}";
            Email = customer.Email;
            Phone = customer.Phone;
            Mobile = customer.Mobile;
            Adress = customer.Address;
            ZipCode = customer.ZipCode;
            City = customer.City;
            Country = customer.Country;
        }
    }
}
