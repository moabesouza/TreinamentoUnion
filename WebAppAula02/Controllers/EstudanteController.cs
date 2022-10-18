using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAula02.Controllers
{
    public class EstudanteController : Controller
    {
        // GET: EstudanteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstudanteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstudanteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudanteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstudanteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstudanteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstudanteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstudanteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
