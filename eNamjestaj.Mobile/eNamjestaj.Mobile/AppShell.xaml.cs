using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.ViewModels;
using eNamjestaj.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eNamjestaj.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            Routing.RegisterRoute(nameof(RegistracijaPage), typeof(RegistracijaPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            Routing.RegisterRoute(nameof(ProfilPage), typeof(ProfilPage));
            Routing.RegisterRoute(nameof(ProfilEditPage), typeof(ProfilEditPage));

            Routing.RegisterRoute(nameof(ProizvodiPage), typeof(ProizvodiPage));
            Routing.RegisterRoute(nameof(ProizvodDetailPage), typeof(ProizvodDetailPage));

            Routing.RegisterRoute(nameof(NarudzbaPage), typeof(NarudzbaPage));
            Routing.RegisterRoute(nameof(HistorijaNarudzbiPage), typeof(HistorijaNarudzbiPage));
            Routing.RegisterRoute(nameof(HistorijaNarudzbiDetailPage), typeof(HistorijaNarudzbiDetailPage));

            Routing.RegisterRoute(nameof(AkcijskiKatalogPage), typeof(AkcijskiKatalogPage));
            Routing.RegisterRoute(nameof(AkcijskiKatalogProizvodDetailPage), typeof(AkcijskiKatalogProizvodDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            AktivnaNarudzba.Narudzba = null;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
