using Microsoft.EntityFrameworkCore;
using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Data.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly AppDbContext _context;
        public ProducerRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Producer producerToDelete = _context.Producers.Find(id);
            if (producerToDelete != null)
            {
                _context.Producers.Remove(producerToDelete);
                _context.SaveChanges();
            }
        }

        public void Delete(Producer producer)
        {
            Producer producerToDelete = _context.Producers.Find(producer.Id);
            if (producerToDelete != null)
            {
                _context.Producers.Remove(producerToDelete);
                _context.SaveChanges();
            }
        }

        public void Edit(Producer producer)
        {
            Producer existingProducer = _context.Producers.Find(producer.Id);
            if (existingProducer != null)
            {
                existingProducer.ProfilePictureURL = producer.ProfilePictureURL;
                existingProducer.FullName = producer.FullName;
                existingProducer.Bio = producer.Bio;
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Producer>> GetAll()
        {
            var result = await _context.Producers.ToListAsync();
            return result;
        }

        public Producer GetById(int id)
        {
            return _context.Producers.Find(id);
        }

        public Producer Update(int id, Producer newProducer)
        {
            Producer existingProducer = _context.Producers.Find(id);
            if (existingProducer != null)
            {
                existingProducer.ProfilePictureURL = newProducer.ProfilePictureURL;
                existingProducer.FullName = newProducer.FullName;
                existingProducer.Bio = newProducer.Bio;
                _context.SaveChanges();
            }
            return existingProducer;
        }

        void IProducerRepository.Update(int id, Producer newProducer)
        {
            throw new NotImplementedException();
        }
    }

}