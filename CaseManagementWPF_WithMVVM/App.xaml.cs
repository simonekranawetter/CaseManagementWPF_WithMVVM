﻿using CaseManagementWPF_WithMVVM.ViewModels;
using CaseManagementWPF_WithMVVM.Data;
using CaseManagementWPF_WithMVVM.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CaseManagementWPF_WithMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            var mainViewModel = new MainViewModel();
            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
