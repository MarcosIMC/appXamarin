using App1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "App Xamarin";

            btnIniciarSesion.Clicked += bntInicioSesion_Clicked;
        }

        private void bntInicioSesion_Clicked(object sender, EventArgs e)
        {
            //Inicio de peticion server
            ((NavigationPage)this.Parent).PushAsync(new Home());
        }
    }
}
