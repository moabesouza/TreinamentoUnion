using Microsoft.AspNetCore.Mvc;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepository _usuarioRespository;

        public UsuarioController(IUsuarioRepository usuarioRespository)
        {
            _usuarioRespository = usuarioRespository;
        }

        public async Task<IActionResult> Index()
        {
            var aux = await _usuarioRespository.GetAll();
            return View(aux);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel novoUsuario)
        {
            
            try
            {
                
                if (!ModelState.IsValid) return View(novoUsuario);
                novoUsuario.DataCadastro = DateTime.Now;
                await _usuarioRespository.Add(novoUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioRespository.Get(id);

            if (usuario == null) return NotFound();


            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
 
        public async Task<IActionResult> Edit(UsuarioViewModel usuario)
        {
            try
            {
                if (!ModelState.IsValid) return View(usuario);
                usuario.DataAtualizacao = DateTime.Now;

                await _usuarioRespository.Update(usuario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioRespository.Get(id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var usuario = await _usuarioRespository.FirstOrDefault(x => x.Id == id);

            if (usuario == null) return NotFound();

            await _usuarioRespository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}


