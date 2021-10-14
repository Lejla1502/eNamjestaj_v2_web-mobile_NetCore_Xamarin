using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.Views;
using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNamjestaj.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");
        private readonly APIService _kupacservice = new APIService("Kupac");
        private readonly APIService _narudzbaservice = new APIService("Narudzba");


        private readonly APIService _katalogService = new APIService("AkcijskiKatalog");
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Registracija());
        }

        async Task Registracija()
        {
            Application.Current.MainPage = new RegistracijaPage();
            
        }

        async Task Login()
        {
            IsBusy = true;
            if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Pogresno korisnicko ime ili lozinka", "OK");
                return;
            }
            APIService.Username = Username;
            APIService.Password = Password;
            var request = new KorisnikAutentikacijaRequest()
            {
                Username = APIService.Username,
                Password = APIService.Password
            };

            var kor = await _service.Authenticiraj(request);



            if (kor != null)
            {
                var korRole = kor.UlogaId;
                if (korRole ==5)
                {
                    Application.Current.MainPage = new AppShell();//new MainPage();
                    LogovaniKorisnikHelper.Korisnik = kor;
                    LogovaniKupacHelper.Kupac = await _kupacservice.GetByKorisnikId<Model.Kupac>(kor.Id);

                    try
                    {
                        var n = await _narudzbaservice.GetAktivnaNarudzbaByKupacId<Model.Narudzba>(LogovaniKupacHelper.Kupac.Id);
                        if (n != null && n.Aktivna)
                        {
                            AktivnaNarudzba.Narudzba = n;
                        }

                    }
                    catch (Exception e)
                    {
                        return;
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Pogresno korisnicko ime ili lozinka", "OK");
            }
            /* var akcKataloziList = await _katalogService.Get<List<AkcijskiKatalog>>(null);

             foreach (var kat in akcKataloziList)
             {
                 if (kat.Aktivan)
                     CartService.AktivanKatalog = kat.Id;
             }
            */
           
            
        }
        /*
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }*/



    }
}
