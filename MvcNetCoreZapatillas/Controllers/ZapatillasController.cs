using Microsoft.AspNetCore.Mvc;
using MvcNetCoreZapatillas.Models;
using MvcNetCoreZapatillas.Repositories;

namespace MvcNetCoreZapatillas.Controllers
{
    public class ZapatillasController : Controller
    {
        private RepositoryZapatillas repo;

        public ZapatillasController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Zapatillas()
        {
            List<Zapatilla> zapatillas = this.repo.GetZapatillas();
            return View(zapatillas);
        }

        public IActionResult DetallesZapatillas(int idproducto)
        {
            return View(this.repo.DetallesZapatillas(idproducto));
        }

        public IActionResult _PartialZapatillas(int idproducto, int posicion)
        {
            if(posicion == null)
            {
                posicion = 1;
            }
            ViewData["TOTAL"] = this.repo.TotalImagenes(idproducto);
            ViewData["POSICION"] = posicion;
            ImagenZapatilla imgzapas = this.repo.GetImagen(idproducto, posicion);
            return PartialView("_PartialZapatillas", imgzapas);
        }

        public IActionResult ImagenZapatilla(int idproducto, int posicion)
        {
            if (posicion == null)
            {
                posicion = 1;
            }
            ViewData["TOTAL"] = this.repo.TotalImagenes(idproducto);
            ViewData["POSICION"] = posicion;
            ImagenZapatilla imgzapas = this.repo.GetImagen(idproducto, posicion);
            return View(imgzapas);
        }
    }
}
