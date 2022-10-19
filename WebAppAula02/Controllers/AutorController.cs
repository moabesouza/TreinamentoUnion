using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorRepository _autorRespository;
        private readonly ILivroRepository _livroRespository;

        public AutorController(IAutorRepository autorRespository,
            ILivroRepository livroRespository)
        {
            _autorRespository = autorRespository;
            _livroRespository = livroRespository;
        }

        public async Task<IActionResult> Index()
        {
            var aux = await _autorRespository.GetAll();   
            return View(aux);
        }

        public async Task<IActionResult> Details(int id)
        {
            var autor = await _autorRespository.Get(id);

            if (autor == null) return NotFound();

            var listaLivros = await _livroRespository.GetWhere(l => l.AutorId == id);

            var detalhesAutor = new AutorLivrosVM()
            {
                Nome = autor.Nome,
                Livros = listaLivros != null ? listaLivros : new List<LivroViewModel>()
            };

            return View(detalhesAutor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorViewModel novoAutor)
        {
            try
            {
                if(!ModelState.IsValid) return View(novoAutor);
                await _autorRespository.Add(novoAutor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var autor = await _autorRespository.Get(id);

            if (autor == null) return NotFound();


            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AutorViewModel autor)
        {
            try
            {
                if (!ModelState.IsValid) return View(autor);

                await _autorRespository.Update(autor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var autor = await _autorRespository.Get(id);

            if (autor == null) return NotFound();

            return View(autor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var autor = await _autorRespository.FirstOrDefault( x => x.Id == id);

            if (autor == null) return NotFound();

            await _autorRespository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
