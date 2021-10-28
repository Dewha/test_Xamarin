﻿using System;
using test_App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ChannelsPage());
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