using NetflixRoullette.Services.Interfaces;
using NetflixRoullette.Services.Mock;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetflixRoullette
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IMoviesService, InMemoryMoviesService>();
            DependencyService.Register<IUserService, InMemoryUsersService>();

            MainPage = new MainPage();
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
