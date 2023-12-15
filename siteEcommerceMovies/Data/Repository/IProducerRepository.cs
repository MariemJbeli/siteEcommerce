using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Data.Repository
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> GetAll();
        Producer GetById(int id);
        void Add(Producer producer);
        void Update(int id, Producer newProducer);
        void Delete(int id);
        void Delete(Producer producer);
        void Edit(Producer producer);
    }
}
