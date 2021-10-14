using eNamjestaj.Mobile.Helpers;
using eNamjestaj.Mobile.Views;
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
    public class HistorijaViewModel:BaseViewModel
    {
        private readonly APIService _narudzbaService = new APIService("Narudzba");
        private readonly APIService _izlazService = new APIService("Izlaz");

        public ObservableCollection<NarudzbaHistorijaDisplayRequest> Narudzbe { get; }


        public ICommand LoadItemsCommand { get; set; }
        public Command<NarudzbaHistorijaDisplayRequest> NarudzbaTapped { get; }

        private NarudzbaHistorijaDisplayRequest _selectedNarudzba;

        public NarudzbaHistorijaDisplayRequest SelectedNarudzba
        {
            get => _selectedNarudzba;
            set
            {
                SetProperty(ref _selectedNarudzba, value);
                OnItemSelected(value);
            }
        }

        public HistorijaViewModel()
        {
            Narudzbe = new ObservableCollection<NarudzbaHistorijaDisplayRequest>();

            NarudzbaTapped = new Command<NarudzbaHistorijaDisplayRequest>(OnItemSelected);
            LoadItemsCommand = new Command(async () => await Init());
        }

        public ObservableCollection<NarudzbaHistorijaDisplayRequest> NArudzbaList { get; set; } = new ObservableCollection<NarudzbaHistorijaDisplayRequest>();

        public string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        

        public async Task Init()
        {
            SelectedNarudzba = null;
            var narudzbe=await _narudzbaService.GetHistorijaNArudzbiByKupacId<List<NarudzbaHistorijaDisplayRequest>>(LogovaniKupacHelper.Kupac.Id);

          
            NArudzbaList.Clear();
            foreach (var item in narudzbe)
            {
                

                NArudzbaList.Add(item);
            }
        }

        async void OnItemSelected(NarudzbaHistorijaDisplayRequest item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack

            // Application.Current.MainPage = new HistorijaNarudzbiDetailPage(item.Id);
            await Shell.Current.GoToAsync($"{nameof(HistorijaNarudzbiDetailPage)}?{nameof(HistorijaDetailViewModel.NarudzbaId)}={item.Id}");
        }
    }
}
