using ETicket.Data;
using ETicket.Interfaces;
using ETicket.Models;
using ETicket.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace ETicket.Repositories
{
    public class MoviesServices : BaseRepository<Movie> , IMoviesService
    {
        protected readonly AppDbContext _context;
        public MoviesServices(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<NewMovieDropdownsModel> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsModel()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Parties = await _context.Parties.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }
        public async Task AddNewMovieAsync(NewMovieModel data)
        {

            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                moviecategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

            //Add Movie Cinemas
            foreach (var cinemaId in data.CinemaIds)
            {
                var newcinemaMovie = new Cinemas_Movies()
                {
                    MovieId = newMovie.Id,
                    CinemaId = cinemaId
                };
                await _context.Cinemas_Movies.AddAsync(newcinemaMovie);
            }
            await _context.SaveChangesAsync();

            //Add Movie Parties
            foreach (var partyId in data.PartiesIds)
            {
                var newPartiesMovie = new Parties_Movies()
                {
                    MovieId = newMovie.Id,
                    PartyId = partyId
                };
                await _context.Parties_Movies.AddAsync(newPartiesMovie);
            }
            await _context.SaveChangesAsync();
        }

        

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(p => p.Producer)
                .Include(cm => cm.Cinemas_Movies).ThenInclude(c => c.Cinema)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .Include(pm => pm.Parties_Movies).ThenInclude(p => p.Parties)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task UpdateMovieAsync(NewMovieModel data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                //abanoubdbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.moviecategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actor_Movies.RemoveRange(existingActorsDb);

            var existingCinemasDb = _context.Cinemas_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Cinemas_Movies.RemoveRange(existingCinemasDb);

            var existingPartiessDb = _context.Parties_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Parties_Movies.RemoveRange(existingPartiessDb);

            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }

            //Add Movie Cinemas
            foreach (var cinemaId in data.CinemaIds)
            {
                var newCinemaMovie = new Cinemas_Movies()
                {
                    MovieId = data.Id,
                    CinemaId = cinemaId
                };
                await _context.Cinemas_Movies.AddAsync(newCinemaMovie);
            }

            //Add Movie Parties
            foreach (var partyId in data.PartiesIds)
            {
                var newPartyMovie = new Parties_Movies()
                {
                    MovieId = data.Id,
                    PartyId = partyId
                };
                await _context.Parties_Movies.AddAsync(newPartyMovie);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            /*var ActorsRelatedThisMovie = await _context.Actor_Movies.Where(n => n.MovieId == id).ToListAsync();

            _context.Actor_Movies.RemoveRange(ActorsRelatedThisMovie);
            await _context.SaveChangesAsync();*/

            var movieDetails = await _context.Movies
                //abanoub.Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            _context.Movies.Remove(movieDetails);
            await _context.SaveChangesAsync();
        }
    }
}
