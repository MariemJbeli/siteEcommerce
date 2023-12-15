using Microsoft.EntityFrameworkCore;
using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Data.Repository
{
    public class ActorRepository : IActorsRepository
    {
        private readonly AppDbContext _context;
        public ActorRepository(AppDbContext context) 
        {
            _context = context;
        }
        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Actor actorToDelete = _context.Actors.Find(id);
            if (actorToDelete != null)
            {
                _context.Actors.Remove(actorToDelete);
                _context.SaveChanges();
            }
        }

        public void Delete(Actor actor)
        {
            Actor actorToDelete = _context.Actors.Find(actor.Id);
            if (actorToDelete != null)
            {
                _context.Actors.Remove(actorToDelete);
                _context.SaveChanges();
            }
        }

        public void Edit(Actor actor)
        {
            Actor existingActor = _context.Actors.Find(actor.Id);
            if (existingActor != null)
            {
                existingActor.ProfilePictureURL = actor.ProfilePictureURL;
                existingActor.FullName = actor.FullName;
                existingActor.Bio = actor.Bio;
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public Actor GetById(int id)
        {
            return _context.Actors.Find(id);
        }

        public Actor Update(int id, Actor newActor)
        {
            Actor existingActor = _context.Actors.Find(id);
            if (existingActor != null)
            {
                existingActor.ProfilePictureURL = newActor.ProfilePictureURL;
                existingActor.FullName = newActor.FullName;
                existingActor.Bio = newActor.Bio;
                _context.SaveChanges();
            }
            return existingActor;
        }

        void IActorsRepository.Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
