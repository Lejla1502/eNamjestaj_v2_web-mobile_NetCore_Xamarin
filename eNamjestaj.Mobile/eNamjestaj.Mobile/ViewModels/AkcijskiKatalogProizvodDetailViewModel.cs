using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.Views;
using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNamjestaj.Mobile.ViewModels
{
    [QueryProperty(nameof(ProizvodId), nameof(ProizvodId))]
    public class AkcijskiKatalogProizvodDetailViewModel:BaseViewModel
    {
        private readonly APIService _proizvodiService = new APIService("Proizvod");
        private readonly APIService _bojeProizvodaService = new APIService("Boja");
        private readonly APIService _skladisteService = new APIService("ProizvodSkladiste");
        private readonly APIService _narudzbaService = new APIService("Narudzba");
        private readonly APIService _narudzbaStavkaService = new APIService("NarudzbaStavka");
        private readonly APIService _recenzijaService = new APIService("Recenzija");



        public ObservableCollection<Boja> BojaProizvodaList { get; set; } = new ObservableCollection<Boja>();
        public ObservableCollection<RecenzijaDisplayRequest> RecenzijaList { get; set; } = new ObservableCollection<RecenzijaDisplayRequest>();
        public ObservableCollection<Model.Proizvod> ListaPreporucenihProizvoda { get; set; } = new ObservableCollection<Model.Proizvod>();



        public ICommand PovecajKolicinuCommand { get; set; }

        public ICommand NaruciCommand { get; set; }

        public ICommand SmanjiKolicinuCommand { get; set; }
        public ICommand RecommendCommand { get; set; }

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

        public AkcijskiKatalogProizvodDetailViewModel()
        {
            PovecajKolicinuCommand = new Command(PovecajKolicinu);
            SmanjiKolicinuCommand = new Command(SmanjiKolicinu);
            NaruciCommand = new Command(async () => await Naruci());
            // InitCommand = new Command(async () => await Init());
            RecommendCommand = new Command(async () => await RecommendProduct(ProizvodId));
            CarouselItemTapped = new Command<Proizvod>(OnItemSelected);


        }

        async void OnItemSelected(Proizvod item)
        {
            if (item == null)
                return;

            var found=await _proizvodiService.CheckIfProductInCatalogue<bool>(item.Id);

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

        ProizvodKatalogDisplayRequest proizvod = new ProizvodKatalogDisplayRequest();

        private int _proizvodId;
        public int ProizvodId
        {
            get
            {
                return _proizvodId;
            }
            set
            {

                _proizvodId = value;
                LoadProizvod(value);
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
            if (Kolicina > 1)
                Kolicina -= 1;
            else
                App.Current.MainPage.DisplayAlert("Alert", "Ne mozete vise smanjivati kolicinu!", "OK");
        }

        int _kolicina = 0;
        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }

        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }


        string _cijena = string.Empty;
        public string Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }


        string _popust = string.Empty;
        public string Popust
        {
            get { return _popust; }
            set { SetProperty(ref _popust, value); }
        }

        public string _sifra = string.Empty;
        public string Sifra 
        {
            get { return _sifra; }
            set { SetProperty(ref _sifra, value); }
        }

        public string _cijenaSaPopustom = string.Empty;
        public string CijenaSaPopustom 
        {
            get { return _cijenaSaPopustom; }
            set { SetProperty(ref _cijenaSaPopustom, value); }
        }

        public string _slika = string.Empty;
        public string Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
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



        Boja _selectedBojaProizvoda = null;
        public Boja SelectedBojaProizvoda
        {
            get { return _selectedBojaProizvoda; }
            set
            {
                SetProperty(ref _selectedBojaProizvoda, value);
                /*if (value != null)
                {
                    InitCommand.Execute(null);
                }*/
            }
        }

        public async void LoadProizvod(int itemId)
        {
            if (BojaProizvodaList.Count == 0)
            {
                var bojaProizvodaList = await _bojeProizvodaService.GetBojeByProizvodId<List<Boja>>(itemId);

                foreach (var boja in bojaProizvodaList)
                {
                    BojaProizvodaList.Add(boja);
                }
            }

            var recenzijeList = await _recenzijaService.GetRecenzijaByProizvodId<IEnumerable<RecenzijaDisplayRequest>>(itemId);

            RecenzijaList.Clear();
            foreach (var item in recenzijeList)
            {

                RecenzijaList.Add(item);
            }

            if (RecenzijaList.Count > 0)
                LblKomentar = "Komentari:";

            proizvod = await _proizvodiService.GetProizvodKatalogByProizvodId<ProizvodKatalogDisplayRequest>(itemId);

            Naziv = proizvod.Naziv;
            Cijena = proizvod.Cijena.ToString("0.00");
            Popust = proizvod.Popust.ToString("0.00");
            Sifra = proizvod.Sifra;
            CijenaSaPopustom = proizvod.CijenaSaPopustom.ToString("0.00");
            string s = "Assets";

            Slika =s+ proizvod.Slika;
            
        }


        private async Task Naruci()
        {

            var kol = await _skladisteService.GetSkladisteKolicinaByProizvodId<int>(ProizvodId);
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
            if (Kolicina != 0)
            {
               
                decimal cijena = Convert.ToDecimal(Cijena);
                decimal po = Convert.ToDecimal(Popust);
                int popustInt = Convert.ToInt32(po);

                var postotakODCijene = (cijena * popustInt / 100);
                var konacnaCijena = cijena - postotakODCijene;
                var multiply = konacnaCijena * Kolicina;


                if (AktivnaNarudzba.Narudzba == null)
                {
                    int brojN = 1;

                    try
                    {
                        var narLast = await _narudzbaService.GetLast<Model.Narudzba>();
                        if (narLast != null)
                            brojN = Convert.ToInt32(narLast.BrojNarudzbe.Split('-').Last()) + 1;


                    }
                    catch (Exception e)
                    {
                        return;
                    }
                    var nar = new NarudzbaInsertRequest
                    {
                        BrojNarudzbe = "BN-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + brojN,
                        Datum = DateTime.Now,
                        Status = true,
                        Aktivna = true,
                        DostavaId = "1",
                        NaCekanju = false,
                        Odbijena = false,
                        Otkazano = false,
                        KupacId = LogovaniKupacHelper.Kupac.Id,
                        Total = 0
                    };

                    var provjera = await _narudzbaService.Insert<Model.Narudzba>(nar);
                    if (provjera != null)
                    {
                        AktivnaNarudzba.Narudzba = provjera;

                        
                        
                        var narStavka = new NarudzbaStavkaUpsertRequest
                        {
                            Kolicina = Kolicina,
                            BojaId = SelectedBojaProizvoda.Id,
                            ProizvodId = ProizvodId,
                            NarudzbaId = provjera.Id,
                            CijenaProizvoda =cijena,
                            PopustNaCijenu = popustInt,
                            TotalStavke = multiply
                        };

                        var modelNarStavke = await _narudzbaStavkaService.Insert<Model.NarudzbaStavka>(narStavka);

                        await Application.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste dodali u korpu!!", "Ok");
                    }
                }
                else
                {
                    int? stavkaId = await _narudzbaStavkaService.GetStavkaIdByNarudzbaIProizvod<int>(AktivnaNarudzba.Narudzba.Id, ProizvodId, SelectedBojaProizvoda.Id);
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
                            BojaId = SelectedBojaProizvoda.Id,
                            CijenaProizvoda = cijena,
                            Kolicina = Kolicina,
                            NarudzbaId = AktivnaNarudzba.Narudzba.Id,
                            PopustNaCijenu = popustInt,
                            ProizvodId = ProizvodId,
                            TotalStavke = multiply
                        };

                        await _narudzbaStavkaService.Insert<Model.NarudzbaStavka>(novaStavka);
                        await Application.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste dodali u korpu!!", "Ok");

                    }
                }
            }
            else
                await Application.Current.MainPage.DisplayAlert("Alert", "Kolicina mora biti veca od 0!", "Ok");


          
        }

        public async Task<bool> OstaviRecenziju(int id)
        {
            if (id == 0)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Potrebno je unijeti ocjenu", "OK");
                return false;
            }
            if (String.IsNullOrEmpty(Komentar) || Komentar.Length<4)
            {
                await App.Current.MainPage.DisplayAlert("Greska", "Ptrebno unijeti komentar. Najmanje 4 karaktera.", "OK");
                return false;

            }
           
            var r = new RecenzijaInsertRequest
            {
                KupacId = LogovaniKupacHelper.Kupac.Id,
                ProizvodId = ProizvodId,
                Datum = DateTime.Now,
                Sadrzaj = Komentar,
                Ocjena = Convert.ToDecimal(id)
            };

            var vracenaRecenzija = await _recenzijaService.InsertRecenziju(r);

            if (vracenaRecenzija != null)
            {
                UcitajRecenzije();
                await App.Current.MainPage.DisplayAlert("Alert", "Uspjesno ste ostavili recenziju", "OK");
                Komentar = "";

                return true;
                //UcitajRecenzije();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Vec ste unijeli recenziju za ovaj proizvod", "OK");
                return false;
            }
        }

        public async void UcitajRecenzije()
        {
            var recenzijeList = await _recenzijaService.GetRecenzijaByProizvodId<IEnumerable<RecenzijaDisplayRequest>>(ProizvodId);
            LblKomentar = "Komentari:";
            RecenzijaList.Clear();
            foreach (var item in recenzijeList)
            {

                RecenzijaList.Add(item);
            }
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

    }
}
