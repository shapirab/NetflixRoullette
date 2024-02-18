using NetflixRoullette.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoullette.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<bool> AddMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int movieId);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task AddActorToMovieAsync(Actor actor, int movieId);
        Task<Movie> GetMovieAsync(int movieId);
        Task<IEnumerable<Movie>>GetMoviesByActor(int actorId);
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        

    }
}
