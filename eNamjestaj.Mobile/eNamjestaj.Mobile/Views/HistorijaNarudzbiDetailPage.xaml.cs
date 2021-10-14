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
    public partial class HistorijaNarudzbiDetailPage : ContentPage
    {
        private HistorijaDetailViewModel model = null;
        //int narudzbaId = 0;

        public HistorijaNarudzbiDetailPage()//(int id)
        {
            InitializeComponent();
            //narudzbaId = id;
            BindingContext = model = new HistorijaDetailViewModel();
            //{
             //   NarudzbaId=id
            //};
        }

        /*protected  override void OnAppearing()
        {
            base.OnAppearing();
          // await model.LoadNarudzbaId(narudzbaId);
        }*/
    }
}