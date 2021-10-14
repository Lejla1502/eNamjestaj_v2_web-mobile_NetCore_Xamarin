using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.ViewModels;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNamjestaj.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NarudzbaPage : ContentPage
    {
        private NarudzbaViewModel model ;
        public NarudzbaPage()
        {
            InitializeComponent();
           // NarudzbaItemsSource =model.GetItems();
           //list.ItemsSource= NarudzbaItemsSource;
            BindingContext = model=new NarudzbaViewModel();
            // BindingContext =model=new NarudzbaViewModel() ;

            
        }

        public object BtnZakljuci { get; private set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadItems();

           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            await model.DeleteItem((int)item.CommandParameter);
        }
    }
}