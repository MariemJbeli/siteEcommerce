using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Data.Repository
{
    public interface IActorsRepository
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        void Update(int id, Actor newActor);
        void Delete(int id);
        void Delete(Actor actor);
        void Edit(Actor actor);

    }
}
