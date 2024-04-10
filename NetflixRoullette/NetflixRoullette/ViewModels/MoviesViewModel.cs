using NetflixRoullette.Models;
using NetflixRoullette.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NetflixRoullette.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private readonly IMoviesService moviesService;
        private readonly INavigationService navigationService;
        private string searchText;
        private Movie selectedMovie;

        private bool refreshing;

        public bool Refreshing
        {
            get => refreshing;
            set => SetValue(ref refreshing, value);
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                SetValue(ref searchText, value);
                SearchByPlayerCommand.Execute(value);
            }
        }

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set
            {
                if (value != null)
                {
                    NavigateToMovieDetails(value);
                    value = null;
                }
                SetValue(ref selectedMovie, value);
            }
        }

        public ICommand SearchByPlayerCommand => new Command<string>(SearchByPlayer);

        public ObservableCollection<Movie> Movies { get; private set; } = 
            new ObservableCollection<Movie>();

        public MoviesViewModel()
        {
            moviesService = DependencyService.Get<IMoviesService>();
            navigationService = DependencyService.Get<INavigationService>();
            PopulateMovies();
        }

        private async void PopulateMovies()
        {
            Refreshing = true;
            Movies.Clear();
            IEnumerable<Movie> movies = await moviesService.GetAllMoviesAsync();
            foreach(Movie movie in movies)
            {
                Movies.Add(movie);
            }
            Refreshing = false;
        }

        private async void SearchByPlayer(string searchText)
        {
            Refreshing = true;
            Movies.Clear();
            
            IEnumerable<Movie> searchResults; 
            if(string.IsNullOrEmpty(searchText))
            {
                searchResults = await moviesService.GetAllMoviesAsync();
            }
            else
            {
                searchResults = await moviesService.GetMoviesByActor(searchText);
            }
            
            foreach (Movie movie in searchResults)
            {
                if (movie != null && movie.Actors != null)
                {
                    Movies.Add(movie);
                }
            }
            Refreshing = false;
        }

        private async void NavigateToMovieDetails(Movie movie)
        {
            await navigationService.DisplayAlert("Navigating", movie.Title, "OK");
        }
    }
}
