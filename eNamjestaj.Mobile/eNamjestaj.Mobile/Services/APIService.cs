using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using Flurl.Http;
using Xamarin.Forms;


namespace eNamjestaj.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;

#if DEBUG
        private string _apiUrl = "http://localhost:37485/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<Model.Korisnik> Authenticiraj(KorisnikAutentikacijaRequest request)
        {
            try
            {
                var url = $"{_apiUrl}/Korisnici/Auth";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<Korisnik>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greska", "Niste autentificirani", "OK");
                return default(Model.Korisnik);
            }
        }


        public async Task<Model.Korisnik> SignUp(KorisnikInsertRequest request)
        {
            try
            {
                var url = $"{_apiUrl}/Korisnici/SignUp";
                return await url.PostJsonAsync(request).ReceiveJson<Korisnik>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                throw;
            }
        }

        public async Task<Model.Kupac> SignUpKupac(KupacInsertRequest request)
        {
            try
            {
                var url = $"{_apiUrl}/Kupac/SignUpKupac";
                return await url.PostJsonAsync(request).ReceiveJson<Kupac>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                throw;
            }
        }
        public async Task<T> GetAktivnaNarudzbaByKupacId<T>(int id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/GetAktivnaNarudzbaByKupacId/{id}";


                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }

        }
        public async Task<T> GetByKorisnikId<T>(int id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/GetByKorisnikId/{id}";


                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }

        }

        public async Task<T> GetLast<T>()
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/GetLast";


                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                throw;
            }

        }


        /*public async Task<T> Get<T>()
        {
            var url = $"{_apiUrl}/{_route}";

            return await url.GetJsonAsync<T>();
        }*/

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {

                if (ex.Call.Response.ResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //MessageBox.Show("Niste authentificirani");
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                }

                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetStavkaIdByNarudzbaIProizvod<T>(object idN, object idP, object idB)
        {
            var url = $"{_apiUrl}/{_route}/GetStavkaIdByNarudzbaIProizvod/{idN}/{idP}/{idB}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetBojeByProizvodId<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/GetBojeByProizvodId/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetSkladisteKolicinaByProizvodId<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/GetSkladisteKolicinaByProizvodId/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetProizvodKatalogByProizvodId<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/GetProizvodKatalogByProizvodId/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetStavkeByNarudzbaId<T>(object id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/GetStavkeByNarudzbaId/{id}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greska", "Niste autentificirani", "OK");
                throw;
            }
        }

        public async Task<T> GetNarudzbaProizvodByNarudzbaId<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/GetNarudzbaProizvodByNarudzbaId/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }



        public async Task<T> GetProizvodiKatalog<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}/GetProizvodiKatalog";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {

                if (ex.Call.Response.ResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //MessageBox.Show("Niste authentificirani");
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                }

                throw;
            }

        }


        public async Task<T> GetHistorijaNArudzbiByKupacId<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/GetHistorijaNArudzbiByKupacId/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> CheckIfProductInCatalogue<T>(int id)
        {
            var url = $"{_apiUrl}/{_route}/CheckIfProductInCatalogue/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Recommend<T>(object kupacId, object proizvodId)
        {

            var url = $"{_apiUrl}/{_route}/Recommend/{kupacId}/{proizvodId}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            //Recommend
        }
        public async Task<T> GetRecenzijaByProizvodId<T>(object id)
        {

            var url = $"{_apiUrl}/{_route}/GetRecenzijaByProizvodId/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            //Recommend
        }

        public async Task Delete(int id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            await url.WithBasicAuth(Username, Password).DeleteAsync();
        }

       /* public async Task DeleteOrderIfNoItemsLeft(int id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            await url.WithBasicAuth(Username, Password).DeleteAsync();
        }*/

        public async Task Zakljuci(int id, Model.Narudzba narudzbaReq)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/Zakljuci/{id}";

                await url.WithBasicAuth(Username, Password).PutJsonAsync(narudzbaReq);
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greska", "Niste autentificirani", "OK");
                throw;
            }
        }

        public async Task<Model.Recenzija> InsertRecenziju(RecenzijaInsertRequest req)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/InsertRecenziju";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(req).ReceiveJson<Recenzija>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greska", "Niste autentificirani", "OK");
                return null;
            }
        }


        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

            }
            return default(T);
        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                throw;
            }

        }
    }
}