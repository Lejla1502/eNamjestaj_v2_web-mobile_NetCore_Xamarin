using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNamjestaj.Mobile.ViewModels
{
    public class AkcijskiKatalogViewModel:BaseViewModel
    {
        private readonly APIService _proizvodiService = new APIService("Proizvod");
        private readonly APIService _vrsteProizvodaService = new APIService("VrstaProizvoda");
        private readonly APIService _bojeProizvodaService = new APIService("Boja");


        public ICommand InitCommand { get; set; }
        public ICommand PretragaCommand { get; set; }
       

        public ObservableCollection<ProizvodKatalogDisplayRequest> ProizvodList { get; }
        public ObservableCollection<VrstaProizvoda> VrstaProizvodaList { get; set; } = new ObservableCollection<VrstaProizvoda>();

        public ObservableCollection<Boja> BojaProizvodaList { get; set; } = new ObservableCollection<Boja>();


        VrstaProizvoda _selectedVrstaProizvoda = null;
        public VrstaProizvoda SelectedVrstaProizvoda
        {
            get { return _selectedVrstaProizvoda; }
            set
            {
                SetProperty(ref _selectedVrstaProizvoda, value);
                /*if (value != null)
                {
                    InitCommand.Execute(null); //kada se promijenila SelectedVrstaProizvoda poziva se InitCommand
                }*/
            }
        }

        Boja _selectedBojaProizvoda = null;
        public Boja SelectedBojaProizvoda
        {
            get { return _selectedBojaProizvoda; }
            set
            {
                SetProperty(ref _selectedBojaProizvoda, value);
                /*if (value != null)
                {
                    InitCommand.Execute(null); //kada se promijenila SelectedVrstaProizvoda poziva se InitCommand
                }*/
            }
        }

        public Command<ProizvodKatalogDisplayRequest> StavkaKatalogTapped { get; }
        private ProizvodKatalogDisplayRequest _selectedStavkaKatalog;

        public ProizvodKatalogDisplayRequest SelectedStavkaKatalog
        {
            get => _selectedStavkaKatalog;
            set
            {
                SetProperty(ref _selectedStavkaKatalog, value);
                OnItemSelected(value);
            }
        }


        public AkcijskiKatalogViewModel()
        {
            SelectedStavkaKatalog = null;
            ProizvodList = new ObservableCollection<ProizvodKatalogDisplayRequest>();
            InitCommand = new Command(async () => await Init());
            PretragaCommand = new Command(async () => await Pretraga());
            StavkaKatalogTapped = new Command<ProizvodKatalogDisplayRequest>(OnItemSelected);
        }

        public async Task Init()
        {
            if (VrstaProizvodaList.Count == 0)
            {
                var vrstaProizvodaList = await _vrsteProizvodaService.Get<List<VrstaProizvoda>>(null);

                foreach (var vrstaProizvoda in vrstaProizvodaList)
                {
                    VrstaProizvodaList.Add(vrstaProizvoda);
                }
            }

            if (BojaProizvodaList.Count == 0)
            {
                var bojaProizvodaList = await _bojeProizvodaService.Get<List<Boja>>(null);

                foreach (var boja in bojaProizvodaList)
                {
                    BojaProizvodaList.Add(boja);
                }
            }
            var listP=await _proizvodiService.GetProizvodiKatalog<IEnumerable<ProizvodKatalogDisplayRequest>>(null);

            if (listP != null)
            {
                string s = "Assets";
                ProizvodList.Clear();
                foreach (var item in listP)
                {

                    string pathSlika = item.Slika;
                    item.Slika = s + item.Slika;
                    ProizvodList.Add(item);
                }
            }
            else
                await App.Current.MainPage.DisplayAlert("Alert", "Trenutno nema nijednog skcijskog kataloga", "OK");
        }

        public async Task Pretraga()
        {
            if (SelectedBojaProizvoda == null && SelectedVrstaProizvoda == null)
                await App.Current.MainPage.DisplayAlert("Greska", "Odaberite parametre za pretragu", "OK");

            if (SelectedVrstaProizvoda != null || SelectedBojaProizvoda != null)
            {

                ProizvodSearchRequest search = new ProizvodSearchRequest();

                if (SelectedVrstaProizvoda != null)
                    search.VrstaProizvodaId = SelectedVrstaProizvoda.Id;

                if (SelectedBojaProizvoda != null)
                    search.BojaId = SelectedBojaProizvoda.Id;


                //za poziv na API koji ce ucitati listu proizvoda i popuniti proizvodiList
                var list = await _proizvodiService.GetProizvodiKatalog<IEnumerable<ProizvodKatalogDisplayRequest>>(search);


                ProizvodList.Clear();
                string s = "Assets";
                foreach (var proizvod in list)
                {
                    string pathSlika = proizvod.Slika;
                    proizvod.Slika = s + proizvod.Slika;
                    ProizvodList.Add(proizvod);
                }

            }
        }

        async void OnItemSelected(ProizvodKatalogDisplayRequest item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack

            // Application.Current.MainPage = new HistorijaNarudzbiDetailPage(item.Id);
            await Shell.Current.GoToAsync($"{nameof(AkcijskiKatalogProizvodDetailPage)}?{nameof(AkcijskiKatalogProizvodDetailViewModel.ProizvodId)}={item.ProizvodId}");
        }

    }
}
