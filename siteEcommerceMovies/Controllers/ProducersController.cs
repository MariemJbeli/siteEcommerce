using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using siteEcommerceMovies.Data;
using siteEcommerceMovies.Data.Repository;
using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        public readonly IProducerRepository _producerRepository;
        public ProducersController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        // GET: ProducersController
        [AllowAnonymous]

        public async Task<ActionResult> Index()
        {
            var data = await _producerRepository.GetAll();

            return View(data);
        }

        // GET: ProducersController/Details/5
        [AllowAnonymous]

        public async Task<ActionResult> Details(int id)
        {
            var pDetails = _producerRepository.GetById(id);

            if (pDetails == null)
                return View("Empty");
            return View(pDetails);
        }

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Producer producer)
        {

            try
            {
                _producerRepository.Add(producer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(producer);
            }
        }

        // GET: ProducersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Producer producer = _producerRepository.GetById(id);


            if (producer == null)
                return View("NotFound");
            return View(producer);
        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Producer newProducer)
        {
            try
            {
                newProducer.Id = id; // Assurez-vous de définir l'ID correctement
                _producerRepository.Edit(newProducer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newProducer);
            }
        }

        // GET: ProducersController/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Producer producer = _producerRepository.GetById(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }

        // POST: ProducersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Producer producer)
        {
            try
            {
                _producerRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
