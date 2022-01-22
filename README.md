# CaseManagementWPF_WithMVVM
Final project for EC Utbildning, WPF App with fully implemented MVVM

Requirements

Make a WPF app with entity framework core. The app is supposed to be a case-handling system to handle different errands like error reports and such. You can chose if you want to do code first or database first.

- You should be able to register a customer with the following information on a page: Name,Email, Phone number, Mobile number, Address (street, postal code, city, country) 
- You should be able to register an errand that is connected to a customer with the following information: Customer, Case headline, Case description, Date created,Date modified 
- The Errand needs to have a status: not started, started, completed
- You should be able to list all customers on a page
- You should be able to list all errands on a page
- All info must be save-able and fetch-able form a normalized SQL database with the help of Entity Framework Core

Additional Requirements
- You should be able to add a customer service representative when creating a case
- You should be able to see detailed information on a case and be able to change status on the case
- On the starting page there would be a list with the 10 latest errands who were entered in the system.
- You should be able to see how many cases are not started, started and completed
