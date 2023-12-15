using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using siteEcommerceMovies.Data;
using siteEcommerceMovies.Data.Repository;
using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        public readonly IActorsRepository _actorsRepository;
        public ActorsController(IActorsRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }
        // GET: ActorsController
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var data = await _actorsRepository.GetAll();

            return View(data);
        }

        // GET: ActorsController/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var actorDetails = _actorsRepository.GetById(id);

            if (actorDetails == null)
                return View("Empty");
            return View(actorDetails);
        }

        // GET: ActorsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ActorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Actor actor)
        {
            
            try
            {
                _actorsRepository.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(actor);
            }
        }

        // GET: ActorsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Actor actor = _actorsRepository.GetById(id);
            
            
            if (actor == null)
                return View("NotFound");
            return View(actor);
        }

        // POST: ActorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Actor newActor)
        {
            try
            {
                newActor.Id = id; // Assurez-vous de définir l'ID correctement
                _actorsRepository.Edit(newActor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newActor);
            }
        }

        // GET: ActorsController/Delete/5
        public ActionResult Delete(int id)
        {
            Actor actor = _actorsRepository.GetById(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        // POST: ActorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Actor actor)
        {
            try
            {
                _actorsRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }






    }
}
