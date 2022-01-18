using CaseManagementWPF_WithMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementWPF_WithMVVM.Data
{
    internal class SqlContext : DbContext
    {
        public  DbSet<Customer> Customers => Set<Customer>();
        public  DbSet<Case> Cases => Set<Case>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Simone\Documents\WIN21\C-Sharp\CaseManagementWPF_WithMVVM\CaseManagementWPF_WithMVVM\Data\Database_File.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
