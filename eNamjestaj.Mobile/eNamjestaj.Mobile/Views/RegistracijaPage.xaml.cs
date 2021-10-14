﻿using eNamjestaj.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNamjestaj.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistracijaPage : ContentPage
    {
        RegistracijaViewModel model = null;
        public RegistracijaPage()
        {
            InitializeComponent();
            BindingContext = model = new RegistracijaViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadInit();
        }
    }
}