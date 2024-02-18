using NetflixRoullette.Models;
using NetflixRoullette.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoullette.Services.Mock
{
    public class InMemoryActorsService : IActorService
    {
        List<Actor> _actors;
        public InMemoryActorsService()
        {
            _actors = new List<Actor>()
            {
                new Actor{Id = 1, FirstName = "Harison", LastName = "Ford"},
                new Actor{Id = 2, FirstName = "Charlie", LastName = "Chaplin"},
                new Actor{Id = 3, FirstName = "Natalie", LastName = "Wood"}
            };
        }


        public async Task<bool> AddActorAsync(Actor actor)
        {
            _actors.Add(actor);
            return true;
        }

        public async Task<bool> DeleteActorAsync(int actorId)
        {
            Actor actorToDelete = await GetActorAsync(actorId);
            _actors.Remove(actorToDelete);
            return true;
        }

        public async Task<Actor> GetActorAsync(int actorId)
        {
            return _actors.Where(actor => actor.Id == actorId).FirstOrDefault();
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            return _actors;
        }

        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            Actor actorToUpdate = await GetActorAsync(actor.Id);
            if(actorToUpdate != null)
            {
                actorToUpdate.FirstName = actor.FirstName;
                actorToUpdate.LastName = actor.LastName;
                return true;
            }
            return false;
        }
    }
}
