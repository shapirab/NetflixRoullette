using NetflixRoullette.Services.Interfaces;
using NetflixRoullette.Services.Mock;
using NetflixRoullette.Views;
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
            DependencyService.Register<IActorService, InMemoryActorsService>();

            MainPage = new NavigationPage(new MoviesPageView());
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
