using NetflixRoullette.Models;
using NetflixRoullette.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetflixRoullette.Services.Mock
{
    public class InMemoryMoviesService : IMoviesService
    {
        private List<Movie> _movies;
        private IActorService _actorService;
        
        public InMemoryMoviesService()
        {
            _movies = new List<Movie>()
            {
                new Movie{ 
                    Id = 1, Title = "Shrek", 
                    CoverUrl = "shrek.png", Year = 1985, 
                    Actors = new List<Actor>()
                    {
                        new Actor { Id = 2, FirstName = "Robin", LastName = "Williams"}
                    }
                },
                new Movie{ 
                    Id = 2, 
                    Title = "Cinderella", 
                    CoverUrl = "cinderella.png", 
                    Year = 1950, 
                    Actors = new List<Actor>()
                },
                new Movie{ 
                    Id = 3, Title = "Goofie", 
                    CoverUrl = "up.jpg", 
                    Year = 2010, 
                    Actors = new List<Actor>()
                },
                new Movie
                {
                    Id = 4,
                    Title = "Terminator",
                    CoverUrl = "exterminator.png",
                    Year = 2015,
                    Actors = new List<Actor>()
                    {
                        new Actor{ Id = 1, FirstName = "Harrison", LastName = "Ford"}
                    }
                }
            };
            _actorService = DependencyService.Get<IActorService>();
        }
        public async Task<bool> AddMovieAsync(Movie movie)
        {
            _movies.Add(movie);
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            Movie movieToDelete = await GetMovieAsync(movieId); 
            _movies.Remove(movieToDelete);
            return true;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            Movie movieToUpdate = await GetMovieAsync(movie.Id);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.CoverUrl = movie.CoverUrl;
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return _movies;
        }

        public async Task<Movie> GetMovieAsync(int movieId)
        {
            return _movies.Where(movie => movie.Id == movieId).FirstOrDefault();
        }

        

        public async Task<IEnumerable<Movie>> GetMoviesByActor(int actorId)
        {
            Actor actor = await _actorService.GetActorAsync(actorId);
            return _movies.Where(movie => movie.Actors.Contains(actor));
        }

        public async Task<IEnumerable<Movie>>GetMoviesByActor(string partialActorName)
        {
            if(partialActorName == null)
            {
                return await GetAllMoviesAsync();
            }
            IEnumerable<Movie>allMovies = await GetAllMoviesAsync();
            IEnumerable<Movie> moviesWithActor = allMovies.Where(movie =>
                movie.Actors.Any(actor =>
                        actor.FirstName.ToLower().Contains(partialActorName.ToLower()) ||
                        actor.LastName.ToLower().Contains(partialActorName.ToLower())));
            return moviesWithActor;
        }

        public async Task AddActorToMovieAsync(Actor actor, int movieId)
        {
            Movie movie = await GetMovieAsync(movieId);
            if(movie != null)
            {
                movie.Actors.Add(actor);
            }
        }
    }
}
