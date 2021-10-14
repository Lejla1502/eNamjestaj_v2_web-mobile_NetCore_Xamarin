using eNamjestaj.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Mobile
{
    public static class CartService
    {
        public static Dictionary<int, ProizvodDetailViewModel> Cart { get; set; } = new Dictionary<int, ProizvodDetailViewModel>();
        public static Dictionary<int, NarudzbaViewModel> Narudzba { get; set; } = new Dictionary<int, NarudzbaViewModel>();

        public static int AktivanKatalog = 0;
    }
}
