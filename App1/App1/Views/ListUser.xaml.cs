using App1.Pojos;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListUser : ContentPage
    {

        public ListUser()
        {
            InitializeComponent();

            getDatas();

            usersList.ItemSelected += ObjectSelection;
        }

        private void ObjectSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {

                var usuarioSeleccionado = (Usuario) e.SelectedItem;

                DisplayAlert("Seleccionado ", usuarioSeleccionado.Nombre, "Ok");
                ((ListView)sender).SelectedItem = null;
            }
        }

        private async void getDatas()
        {
            HttpClient client;
            String url = Constantes.cons.URL_GET_ALL_USERS;

            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder folder = await rootFolder.GetFolderAsync("dataAdmin");

                IFile file = await folder.GetFileAsync("datas.txt");
                String adminData = await file.ReadAllTextAsync();

                var datas = JsonConvert.DeserializeObject<Admin>(adminData);

                //String dni = JsonConvert.SerializeObject(dniAdmin);

                //HttpContent content = new StringContent(dni, Encoding.UTF8, "application/json");

                client = new HttpClient();
                Debug.WriteLine("Antes del response");
                var response = await client.GetStringAsync(Constantes.cons.URL_BASE + url+"?DniAdmin="+datas.Dni);
                Debug.WriteLine("Antes del json");
                var json = JsonConvert.DeserializeObject<List<Usuario>>(response);
                Debug.WriteLine("Antes del observable");
                ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>(json);
                Debug.WriteLine("Antes del list");
                usersList.ItemsSource = listaUsuarios;
            }catch(HttpRequestException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}