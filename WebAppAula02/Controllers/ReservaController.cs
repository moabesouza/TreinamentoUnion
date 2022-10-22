using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebAppAula02.Models;
using WebAppAula02.Repository;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ILivroRepository _livroRespository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutorRepository _autorRespository;
        private readonly IReservaRepository _reservaRespository;

        public ReservaController(ILivroRepository livroRespository,
         IUsuarioRepository usuarioRepository,
         IAutorRepository autorRespository,
         IReservaRepository reservaRespository)
        {
            _livroRespository = livroRespository;
            _usuarioRepository = usuarioRepository;
            _autorRespository = autorRespository;
            _reservaRespository = reservaRespository;
        }


        public async Task<IActionResult> Index()
        {

            var listaReserva = await _reservaRespository.GetAll();

            return View(listaReserva);
        }

        public async Task<IActionResult> Details(int id)
        {
            var reserva = await _reservaRespository.Get(id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        public async Task<IActionResult> Create()
        {
            CreateCombos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva novaReserva)
        {
            try
            {
                if (!ModelState.IsValid) return View(novaReserva);

                await _reservaRespository.Add(novaReserva);

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
            var reserva = await _reservaRespository.Get(id);

            if (reserva == null) return NotFound();

            CreateCombos();
            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Reserva reserva)
        {
            try
            {
                if (!ModelState.IsValid) return View(reserva);

                await _reservaRespository.Update(reserva);

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
            var reserva = await _reservaRespository.Get(id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _reservaRespository.FirstOrDefault(x => x.Id == id);

            if (reserva == null) return NotFound();

            await _reservaRespository.Remove(id);

            return RedirectToAction(nameof(Index));
        }


        private void CreateCombos()
        {

            var l1 = _usuarioRepository.GetAll().Result;

            ViewBag.UsuarioId = l1.Select(x => new SelectListItem
            {
                Text = x.Login,
                Value = x.Id.ToString()
            });


            var l2 = _livroRespository.GetAll().Result;

            ViewBag.Livros = l2.Select(x => new SelectListItem
            {
                Text = x.Titulo,
                Value = x.Id.ToString()
            });


           


        }
    }
}
