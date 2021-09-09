using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Menuprincipal
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        
      
        public MainPage()
        {
            InitializeComponent();
            

        }
        private async void PagNoticias(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Noticias());
        }
        private async void PagControlEscolar(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ControlEscolar());
        }
        private async void PagProximosEventos(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProximosEventos());
        }
        private async void PagEstancias(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Estancias());
        }
        private async void PagInvestigacion(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Investigacion());
        }
        private async void PagAcerca(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Acerca());
        }
        private async void PagGaleria(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Galeria());
        }
        private async void PagConvocatorias(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Convocatorias());
        }

        private async void btn_sesion_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Salir", "Deseas cerrar sesión", "Si", "No");
            if (resp == true) 
            {
                Application.Current.Properties.Clear();
                Navigation.InsertPageBefore(new Login(), this);
                await Navigation.PopAsync();
            }
        }
    }
}
