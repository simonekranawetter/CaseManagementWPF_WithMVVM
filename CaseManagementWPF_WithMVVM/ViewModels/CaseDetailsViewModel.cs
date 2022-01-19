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

        public CaseDetailsViewModel()
        {
            //work on this!
        }
        public CaseStatus Status
        {
            get { return _status; }
            set 
            { 
                _status = value; 
                using(var context = new SqlContext())
                {
                    var myCase = context.Cases
                        .Where(c => c.Id == Id)
                        .First();
                    myCase.Status = _status;
                    context.SaveChanges();
                }
            }
        }

    }

  }
