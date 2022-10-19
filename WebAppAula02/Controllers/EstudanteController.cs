using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAula02.Models;
using WebAppAula02.Repository;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly IEstudanteRepository _estudanteRepository;

        public EstudanteController(IEstudanteRepository estudanteRepository)
        {
            _estudanteRepository = estudanteRepository;
        }

        public async Task<IActionResult> Index()
        {

            var listaEstudantes = await _estudanteRepository.GetAll();

            return View(listaEstudantes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var estudante = await _estudanteRepository.Get(id);

            if (estudante == null) return NotFound();

            return View(estudante);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstudanteViewModel novoEstudante)
        {
            try
            {
                if (!ModelState.IsValid) return View(novoEstudante);

                await _estudanteRepository.Add(novoEstudante);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var estudante = await _estudanteRepository.Get(id);

            if (estudante == null) return NotFound();

            return View(estudante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EstudanteViewModel estudante)
        {
            try
            {
                if (!ModelState.IsValid) return View(estudante);

                await _estudanteRepository.Update(estudante);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var estudante = await _estudanteRepository.Get(id);

            if (estudante == null) return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudante = await _estudanteRepository.FirstOrDefault(x => x.Id == id);

            if (estudante == null) return NotFound();

            await _estudanteRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
