using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.Views;
using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNamjestaj.Mobile.ViewModels
{
    public class ProfilEditViewModel : BaseViewModel
    {
        Model.Korisnik korisnikGlobal = new Model.Korisnik { Id = 0 };

        public ICommand LoadCommand { get; set; }
        public ICommand SpremiCommand { get; set; }

        public ICommand PrekidCommand { get; set; }

        private readonly APIService _korisnikService = new APIService("Korisnici");
        private readonly APIService _kupacService = new APIService("Kupac");
        private readonly APIService _opstinaService = new APIService("Opstina");

        public ObservableCollection<Model.Opstina> OpstinaList { get; set; } = new ObservableCollection<Model.Opstina>();
        int KorisnikId = 0;
        int KupacId = 0;

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

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        string _potvrda = string.Empty;
        public string PasswordPotvrda
        {
            get { return _potvrda; }
            set { SetProperty(ref _potvrda, value); }
        }

        string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        Opstina _opstina = null;
        public Opstina OpstinaProp
        {
            get { return _opstina; }
            set { SetProperty(ref _opstina, value); }
        }

        public ProfilEditViewModel()
        {
            LoadCommand = new Command(async () => await LoadInit());
            SpremiCommand = new Command(async () => await Spremi());
            //PrekidCommand = new Command(async () => await Prekid());
        }



        public async Task LoadInit()
        {
            if (OpstinaList.Count == 0)
            {
                var listOpstine = await _opstinaService.Get<List<Opstina>>(null);
                foreach (var x in listOpstine)
                {
                    OpstinaList.Add(x);
                }
            }


            kor = await _korisnikService.GetById<Model.Korisnik>(LogovaniKorisnikHelper.Korisnik.Id);
            KorisnikId = kor.Id;

            kup = await _kupacService.GetByKorisnikId<Model.Kupac>(kor.Id);
            KupacId = kup.Id;

            op = await _opstinaService.GetById<Model.Opstina>(kor.OpstinaId);

            ImePrezime = kup.Ime + " " + kup.Prezime;
            KorisnickoIme = kor.KorisnickoIme;

            Adresa = kup.Adresa;
            op.Id -= 1;
            OpstinaProp = op;
            Email = kup.Email;
        }

        public async Task Spremi()
        {
            //Username
            if (string.IsNullOrWhiteSpace(KorisnickoIme) || KorisnickoIme.Length < 3)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime je obavezno polje!Minimalna dužina mora biti 3 karaktera", "Ok");
                return;
            }

            //Email

            if (string.IsNullOrWhiteSpace(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Email je obavezno polje!", "Ok");
                return;
            }

            if (!Regex.IsMatch(Email, @"([a-z]+)([\\.]?)([a-z]*)([@])(yahoo|outlook|gmail|hotmail|fit|edu.fit)(.ba|.com|.org)"))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Email mora biti u formatu: neki_naziv@(gmail,hotmail,fit,edu.fit,outlook,yahoo).(ba,com,org)", "Ok");
                return;
            }


            //Password
            if (string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Morate unijeti lozinku da biste spremili promjene!", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(PasswordPotvrda))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Unesi potvrdu lozinke!", "Ok");
                return;
            }

            if (Password != PasswordPotvrda)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Lozinke se ne podudaraju!", "Unesite ponovo");
                return;
            }

            //City
            if (OpstinaProp == null)
            {

                await Application.Current.MainPage.DisplayAlert("Greška", "Odaberi opstinu!", "Ok");
                return;
            }

            //Address
            if (string.IsNullOrWhiteSpace(Adresa))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Adresa je obavezno polje!", "Ok");
                return;
            }


            try
            {
                OpstinaProp.Id += 1;
                var request = new KorisnikUpdateRequest()
                {

                    KorisnickoIme = KorisnickoIme,

                    Password = Password,
                    PasswordConfirmation = PasswordPotvrda,
                    UlogaId = 5,
                    OpstinaId = OpstinaProp.Id
                };




                await _korisnikService.Update<Model.Korisnik>(KorisnikId, request);
                //korisnikGlobal.Id = kor.Id;

            }
            catch (Exception e)
            {
                //await Application.Current.MainPage.DisplayAlert("Greska", e.Message, "OK");
                return;
            }

            await UpdateKupca();



        }

        private async Task UpdateKupca()
        {
            try
            {
                var kupacReq = new KupacUpdateRequest()
                {
                    Email = Email,
                    Adresa = Adresa



                };
                await _kupacService.Update<Model.Kupac>(KupacId, kupacReq);

            }
            catch (Exception e)
            {
                return;
            }

            korisnikGlobal.Id = 0;
            await Application.Current.MainPage.DisplayAlert("Uspjeh", "Uspjesno ste se izmijenili podatke. Da bi ste vidjeli promjene logirajte se ponovo.", "OK");
            Application.Current.MainPage = new LoginPage();
        }


    }
}
