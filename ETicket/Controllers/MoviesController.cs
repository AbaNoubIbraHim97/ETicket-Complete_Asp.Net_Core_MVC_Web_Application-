using ETicket.Data;
using ETicket.Interfaces;
using ETicket.Models;
using ETicket.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{

    public class MoviesController : Controller
    {
        private readonly IMoviesService _MovieService;

        public MoviesController(IMoviesService MovieService)
        {
            _MovieService = MovieService;
        }

        public async Task<IActionResult> Index()
        {
            /*var allMovies = await _context.Movies.Include(c => c.Cinema).OrderBy(O => O.Name).ToListAsync();
            return View(allMovies);*/
            //var allMovies = await _MovieService.GetAllAsync(cm => cm.Cinemas_Movies, am => am.Actor_Movies , p => p.Producer);
            var allMovies = await _MovieService.GetAllAsync();
            return View(allMovies);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _MovieService.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            ViewBag.Parties = new SelectList(movieDropdownsData.Parties, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _MovieService.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                ViewBag.Parties = new SelectList(movieDropdownsData.Parties, "Id", "Name");


                return View(movie);
            }

            await _MovieService.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var MovieDetails = await _MovieService.GetMovieByIdAsync(id);
            return View(MovieDetails);
        }

        [HttpGet]
        [Route("Movies/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _MovieService.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieModel()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.moviecategory,
                //abanoubCinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actor_Movies.Select(n => n.ActorId).ToList(),
                CinemaIds = movieDetails.Cinemas_Movies.Select(n => n.CinemaId).ToList(),
                PartiesIds = movieDetails.Parties_Movies.Select(n => n.PartyId).ToList(),
            };

            var movieDropdownsData = await _MovieService.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            ViewBag.Parties = new SelectList(movieDropdownsData.Parties, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        [Route("Movies/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, NewMovieModel movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _MovieService.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                ViewBag.Parties = new SelectList(movieDropdownsData.Parties, "Id", "Name");

                return View(movie);
            }

            await _MovieService.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Route("Movies/Delete/{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var MovieDetails = await _MovieService.GetMovieByIdAsync(Id);
            if (MovieDetails == null)
            {
                return View("NotFound");
            }
            return View(MovieDetails);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Movies/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            /*var MovieDetails = await _MovieService.GetMovieByIdAsync(Id);
            if (MovieDetails == null)
            {
                return View("NotFound");
            }*/
            await _MovieService.DeleteMovieAsync(Id);
            return RedirectToAction(nameof(Index));

        }
    }
}
