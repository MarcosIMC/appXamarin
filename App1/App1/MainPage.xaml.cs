using App1.Helpers;
using App1.Pojos;
using App1.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {

        HttpClient client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();

            Title = "App Xamarin";

            btnIniciarSesion.Clicked +=  bntInicioSesion_ClickedAsync;
        }

        private void bntInicioSesion_ClickedAsync(object sender, EventArgs e)
        {

            //descargarDatosAsync();

            doLogin(usuario.Text, pass.Text);
//((NavigationPage)this.Parent).PushAsync(new Home());
            /*if (valores != null)
            {
                //Inicio de peticion server
                
            }
            else
            {
                Debug.WriteLine("Es null");
            }*/


        }

        private async void doLogin(String user, String pass)
        {
            if (NetworkCheck.IsInternet())
            {

                HttpClient client;
                String url = "";

                try
                {

                    client = new HttpClient();
                    url = string.Format(Constantes.cons.URL_INICIOSESION);

                    Debug.WriteLine("Antes de await");

                    var response = await client.GetAsync(Constantes.cons.URL_BASE + url+"?email="+user+"&pass="+pass);



                    Debug.WriteLine("Despues de await "+ Constantes.cons.URL_BASE + url + "?email=" + user + "&pass=" + pass);

                    var result = response.Content.ReadAsStringAsync().Result;

                    if (String.IsNullOrEmpty(result) || result.Length.Equals(""))
                    {
                        await DisplayAlert("Error", "Los datos introducidos no son correctos", "Aceptar");

                        
                    }
                    else
                    {
                        Settings.IsLoggedIn = true;
                        ((NavigationPage)this.Parent).PushAsync(new Home());
                    }
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine("Excepcion: " + e.Message);
                }

            }
        }

        private async void descargarDatosAsync()
        {
            if (NetworkCheck.IsInternet())
            {

                HttpClient client;
                String url = "";

                try
                {

                    client = new HttpClient();
                    url = string.Format(Constantes.cons.URL_GET_ALL_USERS);

                    Debug.WriteLine("Antes de await");

                    var response = await client.GetAsync(Constantes.cons.URL_BASE + url);

                    Debug.WriteLine("Despues de await");

                    var result = response.Content.ReadAsStringAsync().Result;

                    if (String.IsNullOrEmpty(result))
                    {
                        await DisplayAlert("Error", "No se obtuvo respuesta del server", "Aceptar");
                    }
                    else
                    {
                        Debug.WriteLine("Response Server: " + result);
                    }

                    /* String url1 = Constantes.cons.URL_BASE + Constantes.cons.URL_GET_ALL_USERS;
                     Debug.WriteLine("URL " + url1);
                     var client1 = new HttpClient();
                     Debug.WriteLine("Antes de await1");
                     var response1 = await client1.GetAsync(url1);

                     string result = await response1.Content.ReadAsStringAsync();*/

                    Debug.WriteLine("eee: " + result);
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine("Excepcion: " + e.Message);
                }

            }


            /*List<Usuario> usuarios = null;
            Debug.WriteLine("Llega al metodo");
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            Debug.WriteLine("Despeus de crear el objeto cliente");
            //var uri = new Uri(Constantes.cons.URL_BASE + Constantes.cons.URL_GET_ALL_USERS);
            String url = Constantes.cons.URL_BASE + Constantes.cons.URL_GET_ALL_USERS;
            Debug.WriteLine("Despeus de crear uri "+url);
            var response = await client.GetAsync(url);
            Debug.WriteLine("Antes del if");
            //usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Dentro del if, respuesta correcta");
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("Despues del content");
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

               // return usuarios;
            }

            //return usuarios;*/
        }
    }
}
    
