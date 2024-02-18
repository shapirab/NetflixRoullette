using NetflixRoullette.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoullette.Services.Interfaces
{
    public interface IActorService
    {
        Task<bool> AddActorAsync(Actor actor);
        Task<bool> DeleteActorAsync(int actorId);
        Task<bool> UpdateActorAsync(Actor actor);
        Task<Actor> GetActorAsync(int actorId);
        Task<IEnumerable<Actor>> GetAllActors();
    }
}
