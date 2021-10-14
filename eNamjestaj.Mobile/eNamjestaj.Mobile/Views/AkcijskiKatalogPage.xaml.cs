using eNamjestaj.Mobile.ViewModels;
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
    public partial class AkcijskiKatalogPage : ContentPage
    {
        private AkcijskiKatalogViewModel model = null;
        public AkcijskiKatalogPage()
        {
            InitializeComponent();
            BindingContext = model = new AkcijskiKatalogViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}