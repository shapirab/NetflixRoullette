using NetflixRoullette.Models;
using NetflixRoullette.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoullette.Services.Mock
{
    public class InMemoryMoviesService : IMoviesService
    {
        public Task<bool> AddMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesByActor(int actorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
