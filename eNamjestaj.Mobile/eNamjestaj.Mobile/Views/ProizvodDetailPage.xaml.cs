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
    public partial class ProizvodDetailPage : ContentPage
    {
        private ProizvodDetailViewModel model = null;
        int id = 0;
        public ProizvodDetailPage(Proizvod p)
        {

            InitializeComponent();
           
            
            BindingContext = model = new ProizvodDetailViewModel()
            {
                Proizvod = p
            };

            

        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }
       
        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            star1.Source = "star_fill.png";
            star2.Source = "star_empty.png";
            star3.Source = "star_empty.png";
            star4.Source = "star_empty.png";
            star5.Source = "star_empty.png";
            id = 1;

            //model.OCijeni(1);
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            star1.Source = "star_fill.png";
            star2.Source = "star_fill.png";
            star3.Source = "star_empty.png";
            star4.Source = "star_empty.png";
            star5.Source = "star_empty.png";

            id = 2;
            //model.OCijeni(2);

        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            star1.Source = "star_fill.png";
            star2.Source = "star_fill.png";
            star3.Source = "star_fill.png";
            star4.Source = "star_empty.png";
            star5.Source = "star_empty.png";

            id = 3;
           // model.OCijeni(3);

        }

        private void ImageButton_Clicked_4(object sender, EventArgs e)
        {
            star1.Source = "star_fill.png";
            star2.Source = "star_fill.png";
            star3.Source = "star_fill.png";
            star4.Source = "star_fill.png";
            star5.Source = "star_empty.png";

            id = 4;
           // model.OCijeni(4);

        }

        private void ImageButton_Clicked_5(object sender, EventArgs e)
        {
            star1.Source = "star_fill.png";
            star2.Source = "star_fill.png";
            star3.Source = "star_fill.png";
            star4.Source = "star_fill.png";
            star5.Source = "star_fill.png";

            id = 5;
            //model.OCijeni(5);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await model.OstaviRecenziju(id))
            {
                star1.Source = "star_empty.png";
                star2.Source = "star_empty.png";
                star3.Source = "star_empty.png";
                star4.Source = "star_empty.png";
                star5.Source = "star_empty.png";

                id = 0;

                //model.UcitajRecenzije();
            }
            
        }
    }
}