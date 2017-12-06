using App1.Pojos;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
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
    public partial class FormPersona : ContentPage
    {
        public FormPersona()
        {
            InitializeComponent();

            Title = "Formulario Usuario";

            setFieldDniAdminAsync();

            save.Clicked += Save_Clicked;
        }

        private async Task setFieldDniAdminAsync()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.GetFolderAsync("dataAdmin");

            IFile file = await folder.GetFileAsync("datas.txt");
            String adminTxt = await file.ReadAllTextAsync();

            var adminData = JsonConvert.DeserializeObject<Admin>(adminTxt);

            dniAdmin.Text = adminData.Dni;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            Usuario user = createObject();

            insertUser(user);

            cleanFields();
        }

        private Usuario createObject()
        {
            String name = nombre.Text;
            String surname = apellidos.Text;
            String dniUser = dni.Text;
            String emailUser = email.Text;
            String dniA = dniAdmin.Text;
            String role = "user";

            Usuario usuario = new Usuario(dniUser, name, surname, emailUser, dniA, role);

            return usuario;
        }

        private async void insertUser(Usuario user)
        {
            HttpClient client;
            String url = Constantes.cons.URL_ADD_USER;

            try
            {

                String userJson = JsonConvert.SerializeObject(user);

                Debug.WriteLine("Valor JSON: " + userJson);

                HttpContent content = new StringContent(userJson, Encoding.UTF8, "application/json");

                client = new HttpClient();

                var response = await client.PostAsync(Constantes.cons.URL_BASE+url, content);

                var result = response.Content.ReadAsStringAsync().Result;

                if(String.IsNullOrEmpty(result) || result.Length.Equals(""))
                {
                    await DisplayAlert("Error", "No se ha podido insertar al usuario.", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Correcto", "El usuario se ha insertado correctamente", "Aceptar");
                }

            }catch(HttpRequestException ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void cleanFields()
        {
            nombre.Text = "";
            apellidos.Text = "";
            dni.Text = "";
            email.Text = "";
            dniAdmin.Text = "";
        }
    }
}