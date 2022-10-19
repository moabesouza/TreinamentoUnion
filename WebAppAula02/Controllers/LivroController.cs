using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebAppAula02.Models;
using WebAppAula02.Repository;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRespository;
        private readonly IEstudanteRepository _estudanteRepository;
        private readonly IAutorRepository _autorRespository;
        private readonly IReservaRepository _reservaRespository;


        public LivroController(ILivroRepository livroRespository,
            IEstudanteRepository estudanteRepository,
            IAutorRepository autorRespository,
            IReservaRepository reservaRespository)
        {
            _livroRespository = livroRespository;
            _estudanteRepository = estudanteRepository;
            _autorRespository = autorRespository;
            _reservaRespository = reservaRespository;
        }

        public async Task<IActionResult> Index()
        {
            var listaLivros = _livroRespository.GetAll();

            return View(listaLivros);
        }

        public async Task<IActionResult> Details(int id)
        {
            var livro = await _livroRespository.Get(id);

            if (livro == null) return NotFound();

            return View(livro);
        }

        public async Task<IActionResult> Create()
        {
            CreateCombos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivroViewModel novoLivro)
        {
            try
            {
                if (!ModelState.IsValid) return View(novoLivro);

                await _livroRespository.Add(novoLivro);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CreateCombos();
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var livro = await _livroRespository.Get(id);

            if (livro == null) return NotFound();

            CreateCombos();
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LivroViewModel livro)
        {
            try
            {
                if (!ModelState.IsValid) return View(livro);

                await _livroRespository.Update(livro);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CreateCombos();
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _livroRespository.Get(id);

            if (livro == null) return NotFound();

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _livroRespository.FirstOrDefault(x => x.Id == id);

            if (livro == null) return NotFound();

            await _livroRespository.Remove(id);

            return RedirectToAction(nameof(Index));
        }


        private void CreateCombos()
        {
            var l1 = _autorRespository.GetAll().Result;

            ViewBag.Autores = l1.Select(x => new SelectListItem
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            });

            
            var l2 = _estudanteRepository.GetAll().Result;

            ViewBag.Estudante = l2.Select(x => new SelectListItem
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            });
        }
    }
}
