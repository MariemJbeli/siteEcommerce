using Microsoft.EntityFrameworkCore;
using siteEcommerceMovies.Models;
using siteEcommerceMovies.Models.ViewModels;

namespace siteEcommerceMovies.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context) 
        {
            _context = context;
        }
        public void Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                Date = data.Date,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

            return newMovie.Id;
        }





        public async Task<IEnumerable<Movie>> GetAll()
        {
            var result = await _context.Movies.ToListAsync();
            return result;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                
                dbMovie.Date = data.Date;
                
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);

            if (movieToDelete != null)
            {
                // Remove associated actors_movies records
                var actorsMoviesToDelete = _context.Actors_Movies.Where(am => am.MovieId == id);
                _context.Actors_Movies.RemoveRange(actorsMoviesToDelete);

                _context.Movies.Remove(movieToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
