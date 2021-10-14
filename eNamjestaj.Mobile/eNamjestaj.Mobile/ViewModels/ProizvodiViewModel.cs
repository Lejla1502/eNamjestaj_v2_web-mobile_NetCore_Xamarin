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
    public class ProizvodiViewModel:BaseViewModel
    {
        private readonly APIService _proizvodiService = new APIService("Proizvod");
        private readonly APIService _vrsteProizvodaService = new APIService("VrstaProizvoda");
        private readonly APIService _bojeProizvodaService = new APIService("Boja");

        public ICommand PretragaCommand { get; set; }
        public ProizvodiViewModel()
        {
            InitCommand = new Command(async() =>await Init());
            PretragaCommand = new Command(async () => await Pretraga());
        }
        public ObservableCollection<Proizvod> ProizvodiList { get; set; } = new ObservableCollection<Proizvod>();
        public ObservableCollection<VrstaProizvoda> VrstaProizvodaList { get; set; } = new ObservableCollection<VrstaProizvoda>();

        public ObservableCollection<Boja> BojaProizvodaList { get; set; } = new ObservableCollection<Boja>();


        //razlog zasto se kreira property jeste zato sto moramo imati metodu "SetProperty" koja ce notificirati
        //sam runtime da se promijenio odredjeni podatak kako bi se mogao nas UI osvjeziti
        VrstaProizvoda _selectedVrstaProizvoda = null;
        //ovdje se cuva informacija kada se promijenila selectovana lista proizvoda
        //picker-u se javlja da kada se promijeni vrsta proizvoda da upise u property SelectedVrstaProizv
        public VrstaProizvoda SelectedVrstaProizvoda
        {
            get { return _selectedVrstaProizvoda; }
            set 
            { 
                SetProperty(ref _selectedVrstaProizvoda, value);
                if (value != null)
                {
                    InitCommand.Execute(null); //kada se promijenila SelectedVrstaProizvoda poziva se InitCommand
                }
            }
        }

        Boja _selectedBojaProizvoda = null;
        //ovdje se cuva informacija kada se promijenila selectovana lista proizvoda
        //picker-u se javlja da kada se promijeni vrsta proizvoda da upise u property SelectedVrstaProizv
        public Boja SelectedBojaProizvoda
        {
            get { return _selectedBojaProizvoda; }
            set
            {
                SetProperty(ref _selectedBojaProizvoda, value);
                if (value != null)
                {
                    InitCommand.Execute(null); //kada se promijenila SelectedVrstaProizvoda poziva se InitCommand
                }
            }
        }



        //kada se pozove komanda pozvace se Init metoda
        public ICommand InitCommand { get; set; }

        public  async Task Init()
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

            //mozda ovdje postaviti da se svi proizvodi ucitaju, eventualno dodati prazno polje u dropdown listi
            

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

                if(SelectedBojaProizvoda!=null)
                    search.BojaId = SelectedBojaProizvoda.Id;


                //za poziv na API koji ce ucitati listu proizvoda i popuniti proizvodiList
                var list = await _proizvodiService.Get<IEnumerable<Proizvod>>(search);


                ProizvodiList.Clear();
                string s = "Assets";
                foreach (var proizvod in list)
                {
                    string pathSlika = proizvod.Slika;
                    proizvod.Slika = s + proizvod.Slika;
                    ProizvodiList.Add(proizvod);
                }

            }
        }
    }
}
