using eNamjestaj.Model;
using eNamjestaj.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using eNamjestaj.Mobile.Views;
using eNamjestaj.Model.Requests;
using eNamjestaj.Mobile.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace eNamjestaj.Mobile.ViewModels
{
    public class ProizvodDetailViewModel:BaseViewModel
    {
        public ProizvodDetailViewModel()
        {
            PovecajKolicinuCommand = new Command(PovecajKolicinu);
            SmanjiKolicinuCommand = new Command(SmanjiKolicinu);
            NaruciCommand = new Command(async()=>await Naruci());
            InitCommand = new Command(async () => await Init());
            RecommendCommand = new Command(async () => await RecommendProduct(Proizvod.Id));
            CarouselItemTapped = new Command<Proizvod>(OnItemSelected);
        }

        private readonly APIService _narudzbaService = new APIService("Narudzba");
        private readonly APIService _narudzbaStavkaService = new APIService("NarudzbaStavka");
        private readonly APIService _skladisteService = new APIService("ProizvodSkladiste");
        private readonly APIService _bojeProizvodaService = new APIService("Boja");
        private readonly APIService _recenzijaService = new APIService("Recenzija");
        private readonly APIService _proizvodiService = new APIService("Proizvod");


        public Command<Proizvod> CarouselItemTapped { get; }

        private Proizvod _selectedCarouselItem;

        public Proizvod SelectedCarouselItem
        {
            get => _selectedCarouselItem;
            set
            {
                SetProperty(ref _selectedCarouselItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Proizvod item)
        {
            if (item == null)
                return;

            var found = await _proizvodiService.CheckIfProductInCatalogue<bool>(item.Id);

            if (found)
            {
                var _navigation = Application.Current.MainPage.Navigation;
                var _lastPage = _navigation.NavigationStack.LastOrDefault();
                //Remove last page
                _navigation.RemovePage(_lastPage);
                //Go back 
                await _navigation.PopAsync();
                await Shell.Current.GoToAsync($"{nameof(AkcijskiKatalogProizvodDetailPage)}?{nameof(AkcijskiKatalogProizvodDetailViewModel.ProizvodId)}={item.Id}");

            }
            else
            {
                var _navigation = Application.Current.MainPage.Navigation;
                var _lastPage = _navigation.NavigationStack.LastOrDefault();
                //Remove last page
                _navigation.RemovePage(_lastPage);
                //Go back 
                await _navigation.PopAsync();
                Proizvod pr = await _proizvodiService.GetById<Model.Proizvod>(item.Id);
                await Application.Current.MainPage.Navigation.PushAsync(new ProizvodDetailPage(item));
                //await Shell.Current.GoToAsync($"{nameof(ProizvodDetailPage)}?{nameof(ProizvodDetailViewModel.ProizvodId)}={pr.Id}");

            }

        }

        private void PovecajKolicinu()
        {
            if (Kolicina < 99)
                Kolicina += 1;
            else
                App.Current.MainPage.DisplayAlert("Alert", "Ne mozete vise dodavati kolicinu!", "OK");
        }

        private void SmanjiKolicinu()
        {
            if (Kolicina >1)
                Kolicina -= 1;
            else
                App.Current.MainPage.DisplayAlert("Alert", "Ne mozete vise smanjivati kolicinu!", "OK");
        }

        public Proizvod Proizvod { get; set; }

        int _kolicina = 0;
        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }

        Boja _selectedBojaProizvoda = null;
        public Boja SelectedBojaProizvoda
        {
            get { return _selectedBojaProizvoda; }
            set
            {
                SetProperty(ref _selectedBojaProizvoda, value);
                if (value != null)
                {
                    InitCommand.Execute(null); 
                }
            }
        }

        public ICommand PovecajKolicinuCommand { get; set; }

        public ICommand NaruciCommand { get; set; }

        public ICommand SmanjiKolicinuCommand { get; set; }

        public ICommand InitCommand { get; set; }

        public ICommand RecommendCommand { get; set; }

        public ObservableCollection<Boja> BojaProizvodaList { get; set; } = new ObservableCollection<Boja>();
        public ObservableCollection<RecenzijaDisplayRequest> RecenzijaList { get; set; } = new ObservableCollection<RecenzijaDisplayRequest>();

        public ObservableCollection<Model.Proizvod> ListaPreporucenihProizvoda { get; set; } = new ObservableCollection<Model.Proizvod>();


        private string _nazivKupca = string.Empty;
        public string NazivKupca
        {
            get { return _nazivKupca; }
            set { SetProperty(ref _nazivKupca, value); }
        }

        private string _komentar = string.Empty;
        public string Komentar
        {
            get { return _komentar; }
            set { SetProperty(ref _komentar, value); }
        }

        private string _lblKomentar = string.Empty;
        public string LblKomentar
        {
            get { return _lblKomentar; }
            set { SetProperty(ref _lblKomentar, value); }
        }

        private string _ocjena = string.Empty;
        public string Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }


        public async Task Init()
        {

            if (BojaProizvodaList.Count == 0)
            {
                var bojaProizvodaList = await _bojeProizvodaService.GetBojeByProizvodId<List<Boja>>(Proizvod.Id);

                foreach (var boja in bojaProizvodaList)
                {
                    BojaProizvodaList.Add(boja);
                }
            }
           
            var recenzijeList = await _recenzijaService.GetRecenzijaByProizvodId<IEnumerable<RecenzijaDisplayRequest>>(Proizvod.Id);

            RecenzijaList.Clear();
            foreach (var item in recenzijeList)
            {

                RecenzijaList.Add(item);
            }

            if (RecenzijaList.Count > 0)
                LblKomentar = "Komentari:";
        }


        private async Task Naruci()
        {

             var kol =await _skladisteService.GetSkladisteKolicinaByProizvodId<int>(Proizvod.Id);
            if (Kolicina > kol)
            {
                await App.Current.MainPage.DisplayAlert("Greska", "Nema na stanju", "Ok");
                return;
            }
            

            if (SelectedBojaProizvoda == null)
            { 
                await App.Current.MainPage.DisplayAlert("Greska", "Molimo odaberite boju", "OK");
                return;
            }
            if (Kolicina != 0 )
            {
                if (AktivnaNarudzba.Narudzba == null)
                {
                    int brojN = 1;

                   
                    var narLast = await _narudzbaService.GetLast<Model.Narudzba>();
                    if (narLast != null)
                         brojN = Convert.ToInt32(narLast.BrojNarudzbe.Split('-').Last()) +1;
                    //int uvecanBr=brojN;
                    //uvecanBr += 1;
                    var nar = new NarudzbaInsertRequest
                    {
                        BrojNarudzbe = "BN-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-"+brojN,
                        Datum = DateTime.Now,
                        Status = true,
                        Aktivna = true,
                        DostavaId = "1",
                        NaCekanju=false,
                        Odbijena=false,
                        Otkazano=false,
                        KupacId = LogovaniKupacHelper.Kupac.Id,
                        Total = 0
                    };

                    var provjera = await _narudzbaService.Insert<Model.Narudzba>(nar);
                    if (provjera != null)
                    {
                        AktivnaNarudzba.Narudzba = provjera;

                        var multiply= Proizvod.Cijena * Kolicina;

                        var narStavka = new NarudzbaStavkaUpsertRequest
                        {
                            Kolicina=Kolicina,
                            BojaId=SelectedBojaProizvoda.Id,
                            ProizvodId=Proizvod.Id,
                            NarudzbaId=provjera.Id,
                            CijenaProizvoda=Proizvod.Cijena,
                            PopustNaCijenu=0,
                            TotalStavke=multiply
                        };

                        var modelNarStavke = await _narudzbaStavkaService.Insert<Model.NarudzbaStavka>(narStavka);

                        await Application.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste dodali u korpu!!", "Ok");
                    }
                }
                else
                {
                    int? stavkaId = await _narudzbaStavkaService.GetStavkaIdByNarudzbaIProizvod<int>(AktivnaNarudzba.Narudzba.Id, Proizvod.Id, SelectedBojaProizvoda.Id);
                    if (stavkaId != 0)
                    {
                        var postojecaStavka = await _narudzbaStavkaService.GetById<Model.NarudzbaStavka>(stavkaId);

                        var stavkaReq = new NarudzbaStavkaUpdateRequest
                        {
                            Kolicina = postojecaStavka.Kolicina + Kolicina
                        };

                        await _narudzbaStavkaService.Update<Model.NarudzbaStavka>(Convert.ToInt32(stavkaId), stavkaReq);

                        await Application.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste dodali u korpu!!", "Ok");

                    }
                    else
                    {
                        var novaStavka = new NarudzbaStavkaUpsertRequest
                        {
                            BojaId=SelectedBojaProizvoda.Id,
                            CijenaProizvoda=Proizvod.Cijena,
                            Kolicina=Kolicina,
                            NarudzbaId=AktivnaNarudzba.Narudzba.Id,
                            PopustNaCijenu=0,
                            ProizvodId=Proizvod.Id,
                            TotalStavke=Kolicina*Proizvod.Cijena
                        };

                        await _narudzbaStavkaService.Insert<Model.NarudzbaStavka>(novaStavka);
                        await Application.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste dodali u korpu!!", "Ok");

                    }
                }
            }
            else
                await Application.Current.MainPage.DisplayAlert("Alert", "Kolicina mora biti veca od 0!", "Ok");
            
            
            /*if (CartService.Cart.ContainsKey(Proizvod.Id))
            {
                CartService.Cart.Remove(Proizvod.Id);
            }
            CartService.Cart.Add(Proizvod.Id, this);*/
                //Application.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste dodali u korpu!!", "Ok");

        }

        async Task RecommendProduct(int id)
        {
            var list = await _proizvodiService.Recommend<List<Model.Proizvod>>(LogovaniKupacHelper.Kupac.Id, id);

            ListaPreporucenihProizvoda.Clear();

            string s = "Assets";
            foreach (var x in list)
            {
                x.Slika = s + x.Slika;
                ListaPreporucenihProizvoda.Add(x);
            }

        }

        public void Ocijeni(int br)
        {
            int kupacId = LogovaniKupacHelper.Kupac.Id;
            //star1
        }

        public async  Task<bool> OstaviRecenziju(int id)
        {
            //string s = id.ToString();
            //App.Current.MainPage.DisplayAlert("Alert", s, "OK");
            if (id == 0)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Potrebno je unijeti ocjenu", "OK");
                return false;
            }
            if (String.IsNullOrEmpty(Komentar) || Komentar.Length < 4)
            {
                await App.Current.MainPage.DisplayAlert("Greska", "Ptrebno unijeti komentar. Najmanje 4 karaktera.", "OK");
                return false;

            }
           

            var r = new RecenzijaInsertRequest
            {
                KupacId = LogovaniKupacHelper.Kupac.Id,
                ProizvodId = Proizvod.Id,
                Datum = DateTime.Now,
                Sadrzaj=Komentar,
                Ocjena=Convert.ToDecimal(id)
            };

            var vracenaRecenzija = await _recenzijaService.InsertRecenziju(r);

            if (vracenaRecenzija != null)
            {
                
                await App.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste ostavili recenziju", "OK");
                Komentar = "";

                UcitajRecenzije();
                return true;
                //UcitajRecenzije();
            }
            else
            {

                await App .Current.MainPage.DisplayAlert("Alert", "Vec ste unijeli recenziju za ovaj proizvod", "OK");
                Komentar = "";

                return false;
            }
        }

        public async void UcitajRecenzije()
        {
            var recenzijeList = await _recenzijaService.GetRecenzijaByProizvodId<IEnumerable<RecenzijaDisplayRequest>>(Proizvod.Id);

            RecenzijaList.Clear();
            foreach (var item in recenzijeList)
            {

                RecenzijaList.Add(item);
            }

            LblKomentar = "Komentari:";
        }

        
    }
}
