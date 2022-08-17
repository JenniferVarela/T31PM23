using System;
using Tarea3_1MV2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T31PM23
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new AgregarAlumnoView());
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
