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
    public class NarudzbaViewModel:BaseViewModel
    {
        public ObservableCollection<ProizvodDetailViewModel> NarudzbaList { get; set; } = new ObservableCollection<ProizvodDetailViewModel>();

        public ICommand LoadItemsCommand { get; set; }
        public ICommand ZakljuciCommand { get; set; }

        private readonly APIService _narudzbaService = new APIService("Narudzba");
        private readonly APIService _narudzbaStavkaService = new APIService("NarudzbaStavka");

        private readonly APIService _izlazService = new APIService("Izlaz");


        private readonly APIService _skladisteService = new APIService("ProizvodSkladiste");
        private readonly APIService _proizvodService = new APIService("Proizvod");

        private readonly APIService _bojeProizvodaService = new APIService("Boja");
        //public ObservableCollection<NarudzbaStavka> NarudzbaList { get; set; } = new ObservableCollection<NarudzbaStavka>();
       
        
        public ObservableCollection<NarudzbaProizvodDisplayRequest> NarudzbeProizvodList { get; }
        public NarudzbaViewModel()
        {
            Title = "Browse";
            NarudzbeProizvodList = new ObservableCollection<NarudzbaProizvodDisplayRequest>();
            LoadItemsCommand = new Command(async () => await LoadItems());
            ZakljuciCommand = new Command(async () => await Zakljuci());
        }


        

        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }

        string _txtIfEmpty = string.Empty;
        public string TextIfEmpty
        {
            get { return _txtIfEmpty; }
            set { SetProperty(ref _txtIfEmpty, value); }
        }

        //za vrijednosti iz baze
        string _ukupno = string.Empty;
        public string Ukupno
        {
            get { return _ukupno; }
            set { SetProperty(ref _ukupno, value); }
        }

        string _ukupnosaPDV = string.Empty;
        public string UkupnoSaPDV
        {
            get { return _ukupnosaPDV; }
            set { SetProperty(ref _ukupnosaPDV, value); }
        }

        string _pdv = string.Empty;
        public string PDVString
        {
            get { return _pdv; }
            set { SetProperty(ref _pdv, value); }
        }


        //za labele u XAML

        string _ukupnolbl = string.Empty;
        public string UkupnoLbl
        {
            get { return _ukupnolbl; }
            set { SetProperty(ref _ukupnolbl, value); }
        }

        string _ukupnosaPDVlbl = string.Empty;
        public string UkupnoSaPDVLbl
        {
            get { return _ukupnosaPDVlbl; }
            set { SetProperty(ref _ukupnosaPDVlbl, value); }
        }

        string _pdvlbl = string.Empty;
        public string PDVStringLbl
        {
            get { return _pdvlbl; }
            set { SetProperty(ref _pdvlbl, value); }
        }

        public async Task LoadItems()
        {
            //ucitati proizvod za svaku stavku da bi se dobio naziv proizvoda 


            if (AktivnaNarudzba.Narudzba != null)
            {
                TextIfEmpty = "";
                Naziv = "Zakljuci narudzbu";

                UkupnoLbl = "Ukupno: ";
                PDVStringLbl = "PDV: ";
                UkupnoSaPDVLbl = "Ukupno sa PDV: ";

                var list = await _narudzbaService.GetNarudzbaProizvodByNarudzbaId<IEnumerable<NarudzbaProizvodDisplayRequest>>(AktivnaNarudzba.Narudzba.Id);

                string s = "Assets";
                decimal sum = 0;
                try
                {
                    NarudzbeProizvodList.Clear();
                    foreach (var item in list)
                    {
                        sum += item.TotalStavka;

                        string pathSlika = item.Slika;
                        item.Slika = s + item.Slika;
                        NarudzbeProizvodList.Add(item);
                    }

                    Ukupno = sum.ToString();

                    decimal PDV = sum * 17 / 100;
                    PDVString = PDV.ToString("0.00");

                    decimal sumSaPDV = sum + PDV;
                    UkupnoSaPDV = sumSaPDV.ToString("0.00");
                }
                catch (Exception e)
                { }
            }
            else
            {
                Naziv = "";

                UkupnoLbl = "";
                PDVStringLbl = "";
                UkupnoSaPDVLbl = "";
                TextIfEmpty = "Trenutno nema aktivnih narudzbi";
                NarudzbeProizvodList.Clear();
                Ukupno = null;

                PDVString = null;

                UkupnoSaPDV = null;
            }
           
        }

        public async Task DeleteItem(int id)
        {
            await _narudzbaStavkaService.Delete(id);
             await _narudzbaService.Delete(AktivnaNarudzba.Narudzba.Id);
            AktivnaNarudzba.Narudzba = await _narudzbaService.GetAktivnaNarudzbaByKupacId<Model.Narudzba>(LogovaniKupacHelper.Kupac.Id);
            await LoadItems();
        }

        public async Task Zakljuci()
        {
            if (AktivnaNarudzba.Narudzba != null)
            {
                await _narudzbaService.Zakljuci(AktivnaNarudzba.Narudzba.Id, AktivnaNarudzba.Narudzba);
                //AktivnaNarudzba.Narudzba.Aktivna = false;
                //AktivnaNarudzba.Narudzba.NaCekanju = true;

                //dio za izlaz
                /*
                Narudzba n = AktivnaNarudzba.Narudzba;
                int broj = 0;

                try
                {
                    var izlLast = await _izlazService.GetLast<Model.Izlaz>();
                    if (izlLast != null)
                        broj = izlLast.BrojFakture.LastIndexOf('-') + 1;
                }
                catch (Exception e)
                {
                    return;
                }

                var izlaz = new IzlazInsertRequest
                {
                    NarudzbaId=AktivnaNarudzba.Narudzba.Id,
                    BrojNarudzbe=n.BrojNarudzbe,
                    Datum=DateTime.Now,
                    Zakljucena=false,
                    IznosBezPdv=Convert.ToDecimal(Ukupno),
                    IznosSaPdv=Convert.ToDecimal(UkupnoSaPDV),
                    PovratNovca=false,
                    DostavaId=1,
                    BrojFakture= "IZLRAC-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + broj
                };

               

                await _izlazService.Insert<Model.Izlaz>(izlaz);*/

                await  App.Current.MainPage.DisplayAlert("Uspjeh", "Uspjesno ste zakljucili narudzbu", "Ok");
                AktivnaNarudzba.Narudzba = null;
                await LoadItems();
                
            }
        }
    }
}
