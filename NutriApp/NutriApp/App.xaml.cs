using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NutriApp.View;

namespace NutriApp
{
    public partial class App : Application
    {
        public App()
        {
#if DEBUG
            HotReloader.Current.Run(this);
#endif
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new LoginPage();
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
