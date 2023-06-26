using ETicket.Data;
using ETicket.Interfaces;
using ETicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly IBaseRepository<Cinema> _CinemaRepository;

        public CinemasController(IBaseRepository<Cinema> CinemaRepository)
        {
            _CinemaRepository = CinemaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _CinemaRepository.GetAllAsync();
            return View(allCinemas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo", "Name", "Description")] Cinema cinema)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _CinemaRepository.AddAsync(cinema);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int Id)
        {

            var CinemaDetails = await _CinemaRepository.GetByIdAsync(Id);
            if (CinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(CinemaDetails);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CinemaDetails = await _CinemaRepository.GetByIdAsync(Id);
            if (CinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(CinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id", "Logo", "Name", "Description")] Cinema newcinema)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _CinemaRepository.UpdateAsync(Id, newcinema);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CinemaDetails = await _CinemaRepository.GetByIdAsync(Id);
            if (CinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(CinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var CinemaDetails = await _CinemaRepository.GetByIdAsync(Id);
            if (CinemaDetails == null)
            {
                return View("NotFound");
            }
            await _CinemaRepository.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));

        }


    }
}
