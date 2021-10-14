using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eNamjestaj.Mobile.ViewModels
{
    [QueryProperty(nameof(NarudzbaId), nameof(NarudzbaId))]

    public class HistorijaDetailViewModel : BaseViewModel
    {
        public ObservableCollection<NarudzbaProizvodDisplayRequest> NarudzbaStavkeList { get; set; } = new ObservableCollection<NarudzbaProizvodDisplayRequest>();
        private readonly APIService _narudzbaService = new APIService("Narudzba");


        private int narudzbaId;
        public int NarudzbaId
        {
            get
            {
                return narudzbaId;
            }
            set
            {

                narudzbaId = value;
                LoadNarudzbaId(value);
            }
        }

        public async void LoadNarudzbaId(int itemId)
        {
            var listaStavki = await _narudzbaService.GetNarudzbaProizvodByNarudzbaId<IEnumerable<NarudzbaProizvodDisplayRequest>>(itemId);


            //var listaStavki=await _narudzbaService.GetStavkeByNarudzbaId<List<NarudzbaProizvodDisplayRequest>>(itemId);

            NarudzbaStavkeList.Clear();

            string s = "Assets";

            foreach (var item in listaStavki)
            {
                string pathSlika = item.Slika;
                item.Slika = s + item.Slika;
                NarudzbaStavkeList.Add(item);
            }

            if (NarudzbaStavkeList == null)
                await App.Current.MainPage.DisplayAlert("Greska", "Stavke se ne mogu ucitati", "OK");
        }
    }
}
