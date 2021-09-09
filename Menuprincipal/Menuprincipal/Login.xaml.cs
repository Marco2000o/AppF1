using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menuprincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            Usuario usu = new Usuario
            {
                Email = txtCorreo.Text,
                Contrasena = txtContrasena.Text,
                Perfil=""
            };
            Uri RutaUri = new Uri("http://192.168.0.6/Practica/Login.php");
            var cliente = new HttpClient();
            var json = JsonConvert.SerializeObject(usu);
            var contenidoJson = new StringContent(json, Encoding.UTF8, "application/json");
            var respuesta = await cliente.PostAsync(RutaUri, contenidoJson);
            try
            {

                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();

                    Usuario tmp = JsonConvert.DeserializeObject<Usuario>(contenido);

                    if (tmp.Respuesta == "Ok")
                    {
                        Application.Current.Properties["correo"] = txtCorreo.Text;
                        Application.Current.Properties["contrasena"] = txtContrasena.Text;
                        Application.Current.Properties["perfil"] = tmp.Perfil;
                        await Application.Current.SavePropertiesAsync();
                        Navigation.InsertPageBefore(new MainPage(), this);
                        await Navigation.PopAsync();
                    }
                    if (tmp.Respuesta == "Ok") { 
                        await Navigation.PushAsync(new MainPage()); 
                    }
                    else

                        await DisplayAlert("Mensaje", "Verifique los datos", "OK");
                }
                else

                    await DisplayAlert("Mensaje", "Error al conectar", "OK");
            }
            catch (Exception Error)
            {
                await DisplayAlert("Mensaje", "ERROR sin entrar", "OK");
            }
        }
    }
}