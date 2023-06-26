using ETicket.Data;
using ETicket.Interfaces;
using ETicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IBaseRepository<Producer> _ProducerRepository;

        public ProducersController(IBaseRepository<Producer> ProducerRepository)
        {
            _ProducerRepository = ProducerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers =await _ProducerRepository.GetAllAsync();
            return View(allProducers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL", "FullName", "Bio")] Producer producer)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _ProducerRepository.AddAsync(producer);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int Id)
        {

            var ProducerDetails = await _ProducerRepository.GetByIdAsync(Id);
            if (ProducerDetails == null)
            {
                return View("NotFound");
            }
            return View(ProducerDetails);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var ProducerDetails = await _ProducerRepository.GetByIdAsync(Id);
            if (ProducerDetails == null)
            {
                return View("NotFound");
            }
            return View(ProducerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id", "ProfilePictureURL", "FullName", "Bio")] Producer newproducer)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _ProducerRepository.UpdateAsync(Id, newproducer);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var ProducerDetails = await _ProducerRepository.GetByIdAsync(Id);
            if (ProducerDetails == null)
            {
                return View("NotFound");
            }
            return View(ProducerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var ProducerDetails = await _ProducerRepository.GetByIdAsync(Id);
            if (ProducerDetails == null)
            {
                return View("NotFound");
            }
            await _ProducerRepository.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));

        }


    }
}
