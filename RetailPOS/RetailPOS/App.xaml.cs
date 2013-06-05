using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using RetailPOS.Core;

namespace RetailPOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += this.Application_StartUp;
            
            InitializeComponent();
        }

        public static string UserName
        {
            get;
            set;
        }

        private void Application_StartUp(object sender, StartupEventArgs e)
        {
            string serviceURL = ConfigurationManager.AppSettings[AppConstants.SERVICE_URL].ToString();
            //call method to initialize the service in factory class 
            ServiceFactory.InitializeServiceFactory(serviceURL);
        }
    }
}