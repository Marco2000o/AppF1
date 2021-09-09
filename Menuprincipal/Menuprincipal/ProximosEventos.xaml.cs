using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menuprincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProximosEventos : ContentPage
    {
        ServicioWeb conexion = new ServicioWeb();
        public ProximosEventos()
        {
            InitializeComponent();
            ProxyListo();
        }
        public void ProxyListo()
        {
            webView.IsVisible = false;
            webView.Source = conexion.dominio + "pilotos.php";
        }

        async private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            indicador.IsRunning = true;
            indicador.IsRunning = true;

            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(15);
            try
            {
                var response = await httpClient.GetAsync(conexion.dominio + "pilotos.php");
                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sin servicio", "Intente mas tarde", "Ok");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                    webView.IsVisible = true;
            }
            catch (Exception error)
            {
                await DisplayAlert("Sin servicio", "Intente mas tarde", "Ok");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            indicador.IsVisible = false;
            vistaOpaca.IsVisible = false;
        }
    }
}