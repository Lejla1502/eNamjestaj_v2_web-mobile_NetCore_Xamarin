using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.Views;
using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNamjestaj.Mobile.ViewModels
{
    public class RegistracijaViewModel:BaseViewModel
    {
        Model.Korisnik korisnikGlobal = new Model.Korisnik { Id = 0 };
        
        public ICommand LoadCommand { get; set; }

        public ICommand RegisterCommand { get; set; }
        public ICommand NazadCommand { get; set; }
        public RegistracijaViewModel()
        {
            LoadCommand = new Command(async () => await LoadInit());
            RegisterCommand = new Command(async () => await Registracija());
            NazadCommand = new Command(async () => await Nazad());
        }

        public async Task Nazad()
        {
            Application.Current.MainPage = new LoginPage();
        }
        

        private readonly APIService _opstinaService = new APIService("Opstina");
        private readonly APIService _korisnikService = new APIService("Korisnici");
        private readonly APIService _kupacService = new APIService("Kupac");



        //private readonly APIService _modelsService = new APIService("carmodels");

        //private readonly APIService _usersService = new APIService("userRegistering");
        public ObservableCollection<Model.Opstina> OpstinaList { get; set; } = new ObservableCollection<Model.Opstina>();

        Opstina _selectedOpstina = null;
        public Opstina SelectedOpstina
        {
            get { return _selectedOpstina; }
            set
            {
                SetProperty(ref _selectedOpstina, value);
                
            }
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
            
            

        }

        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        string _spol = string.Empty;
        public string Spol
        {
            get { return _spol; }
            set { SetProperty(ref _spol, value); }
        }
        string _korisnickoime = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoime; }
            set { SetProperty(ref _korisnickoime, value); }
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


        private async Task Registracija()
        {
            
          
            //Name
            if (string.IsNullOrWhiteSpace(Ime) || Ime.Length < 3)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Ime je obavezno polje!Minimalna dužina mora biti 3 karaktera", "Ok");
                return;


            }

            if (char.IsLower(Ime[0]))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Prvo slovo imena mora biti veliko!", "Ok");
                return;
            }
            bool containsInt = Ime.Any(char.IsDigit);
            if (containsInt)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Brojevi u imenu nisu dozovljeni!", "Ok");
                return;
            }

            //Last name
            if (string.IsNullOrWhiteSpace(Prezime) || Prezime.Length < 3)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Prezime je obavezno polje!Minimalna dužina mora biti 3 karaktera", "Ok");
                return;


            }

            if (char.IsLower(Prezime[0]))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Prvo slovo prezimena mora biti veliko!", "Ok");
                return;
            }
            bool containsInta = Prezime.Any(char.IsDigit);
            if (containsInta)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Brojevi u prezimenu nisu dozovljeni!", "Ok");
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

            

            //Username
            if (string.IsNullOrWhiteSpace(KorisnickoIme) || KorisnickoIme.Length < 3)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime je obavezno polje!Minimalna dužina mora biti 3 karaktera", "Ok");
                return;
            }

          //Password
            if (string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Unesi lozinku!", "Ok");

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
            if (SelectedOpstina == null)
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

            //Gender
            if (string.IsNullOrWhiteSpace(Spol))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Spol je obavezno polje!", "Ok");
                return;
            }
            
                if (!String.Equals(Spol, "M") && !(String.Equals(Spol,"Z")))
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Unesite 'M' ili 'Z'!", "Ok");
                    return;
                }


            if (korisnikGlobal.Id == 0)
            {
                try
                {
                    var request = new KorisnikInsertRequest()
                    {

                        KorisnickoIme = KorisnickoIme,

                        Password = Password,
                        PasswordConfirmation = PasswordPotvrda,
                        UlogaId = 5,
                        OpstinaId = SelectedOpstina.Id
                    };




                    var kor = await _korisnikService.SignUp(request);
                    korisnikGlobal.Id = kor.Id;

                }
                catch (Exception e)
                {
                    //await Application.Current.MainPage.DisplayAlert("Greska", e.Message, "OK");
                    return;
                }
            }
            await InsertKupcaUBazu();
  
            }

        private async Task InsertKupcaUBazu()
        {
            try
            {
                var kupacReq = new KupacInsertRequest()
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    Email = Email,
                    Adresa = Adresa,
                    KorisnikId = korisnikGlobal.Id,
                    Spol = Spol


                };
                await _kupacService.SignUpKupac(kupacReq);

            }
            catch (Exception e)
            {
                return;
            }

            korisnikGlobal.Id = 0;
            await Application.Current.MainPage.DisplayAlert("Uspjeh", "Uspjesno ste se registrovali", "OK");
            Application.Current.MainPage = new LoginPage();
        }


    }
}
