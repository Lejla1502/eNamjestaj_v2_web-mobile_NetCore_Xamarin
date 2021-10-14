using eNamjestaj.Mobile.ViewModels;
using eNamjestaj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNamjestaj.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProizvodiPage : ContentPage
    {
        private ProizvodiViewModel model = null;
        public ProizvodiPage()
        {
            InitializeComponent();
            BindingContext = model = new ProizvodiViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Proizvod;
            await Navigation.PushAsync(new ProizvodDetailPage(item));
           // await Navigation.PushAsync(new NarudzbaPage());
        }
    }
}