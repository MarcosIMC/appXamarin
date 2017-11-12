using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
            Title = "Panel de control";

            btnAlta.Clicked += btnAlta_Clicked;
            btnList.Clicked += btnList_Clicked;
		}

        private void btnList_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btnAlta_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new FormPersona());
        }
    }
}