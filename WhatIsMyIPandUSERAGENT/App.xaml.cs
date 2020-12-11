using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatIsMyIPandUSERAGENT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Paginas.PagPrincipal();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
