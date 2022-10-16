using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppAula02.Models;

namespace WebAppAula02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listaEstudantes = new List<EstudanteViewModel>();

            var x = new EstudanteViewModel()
            {
                Id = 1,
                Nome = "Maria",
                Matricula = ""
            };

            var y = new EstudanteViewModel()
            {
                Id = 2,
                Nome = "Edu",
                Matricula = ""
            };

            var z = new EstudanteViewModel()
            {
                Id = 3,
                Nome = "Caio",
                Matricula = ""
            };

            listaEstudantes.Add(x);
            listaEstudantes.Add(y);
            listaEstudantes.Add(z);

            return View(listaEstudantes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}