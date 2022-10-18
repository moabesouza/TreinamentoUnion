using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAula02.Controllers
{
    public class AutorController : Controller
    {
        // GET: AutorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AutorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
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

        // GET: AutorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutorController/Edit/5
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

        // GET: AutorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutorController/Delete/5
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
