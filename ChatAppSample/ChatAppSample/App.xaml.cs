using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatAppSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Sharpnado.Shades.Initializer.Initialize(true);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
