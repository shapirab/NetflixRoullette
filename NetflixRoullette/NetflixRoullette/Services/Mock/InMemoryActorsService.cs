using NetflixRoullette.Models;
using NetflixRoullette.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoullette.Services.Mock
{
    public class InMemoryActorsService : IActorService
    {
        public Task<bool> AddActorAsync(Actor actor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteActorAsync(int actorId)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> GetActorAsync(int actorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Actor>> GetAllActors()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateActorAsync(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
