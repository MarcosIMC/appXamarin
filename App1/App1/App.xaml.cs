using App1.Helpers;
using App1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new App1.MainPage();

            //Si estamos logueados vamos directamente al inicio
            if (Settings.IsLoggedIn)
            {
                MainPage = new NavigationPage(new Home());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
