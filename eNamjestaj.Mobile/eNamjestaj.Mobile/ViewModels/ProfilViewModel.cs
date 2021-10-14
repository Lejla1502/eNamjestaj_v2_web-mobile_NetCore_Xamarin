using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.Views;
using eNamjestaj.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNamjestaj.Mobile.ViewModels
{
    public class ProfilViewModel : BaseViewModel
    {
        public ICommand LoadCommand { get; set; }
        public ICommand UrediCommand { get; set; }

        private readonly APIService _korisnikService = new APIService("Korisnici");
        private readonly APIService _kupacService = new APIService("Kupac");
        private readonly APIService _opstinaService = new APIService("Opstina");


        public Korisnik kor = new Korisnik();
        public Kupac kup = new Kupac();
        public Opstina op = new Opstina();

        private string _imePrezime = string.Empty;
        public string ImePrezime
        {
            get { return _imePrezime; }
            set { SetProperty(ref _imePrezime, value); }
        }

        private string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        string _opstina = string.Empty;
        public string OpstinaProp
        {
            get { return _opstina; }
            set { SetProperty(ref _opstina, value); }
        }

        public ProfilViewModel()
        {
            LoadCommand = new Command(async () => await LoadInit());
            UrediCommand = new Command(async () => await Uredi());
        }

        public async Task Uredi()
        {
            await Shell.Current.GoToAsync("ProfilEditPage");
           // await Navigation.PushAsync(new ProizvodDetailPage(item));

            //await Shell.Current.GoToAsync($"{nameof(ProfilEditPage)}");
            //await Shell.Current.GoToAsync("page2");

            //Application.Current.MainPage = new ProfilEditPage();

        }

        public async Task LoadInit()
        {
            kor = await _korisnikService.GetById<Model.Korisnik>(LogovaniKorisnikHelper.Korisnik.Id);
           
            kup = await _kupacService.GetByKorisnikId<Model.Kupac>(kor.Id);

            op = await _opstinaService.GetById<Model.Opstina>(kor.OpstinaId);

            ImePrezime = kup.Ime + " " + kup.Prezime;
            KorisnickoIme = kor.KorisnickoIme;
            Email = kup.Email;
            Adresa = kup.Adresa;
            OpstinaProp = op.Naziv;
        }


    }
}
