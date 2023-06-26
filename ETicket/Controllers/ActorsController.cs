using ETicket.Data;
using ETicket.Interfaces;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IBaseRepository<Actor> _Actorrepoistory;

        public ActorsController(IBaseRepository<Actor> Actorrepoistory)
        {
            _Actorrepoistory = Actorrepoistory;
        }

        [Authorize (Roles = "admin , user")]
        public async Task<IActionResult> Index()
        {
            var allActors = await _Actorrepoistory.GetAllAsync();
            return View(allActors);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL", "FullName", "Bio")]Actor actor) 
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _Actorrepoistory.AddAsync(actor);
            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "admin , user")]
        public async Task<IActionResult> Details(int Id) { 
        
            var ActorDetails = await _Actorrepoistory.GetByIdAsync(Id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorDetails);

        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var ActorDetails = await _Actorrepoistory.GetByIdAsync(Id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorDetails);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(int Id,[Bind("Id","ProfilePictureURL", "FullName", "Bio")] Actor newactor)
        {
            /*if (!ModelState.IsValid)
            {
                return View(actor);
            }*/
            await _Actorrepoistory.UpdateAsync(Id , newactor);
            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var ActorDetails = await _Actorrepoistory.GetByIdAsync(Id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorDetails);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var ActorDetails = await _Actorrepoistory.GetByIdAsync(Id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            await _Actorrepoistory.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));

        }
    }
}
