using Microsoft.AspNet.Identity;
using SharedFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedFood.Controllers
{
    public class AyudaController : Controller
    {
        // GET: Ayuda
        public ActionResult Index()
        {
            ViewBag.MiLista = MyBusiness.Donacion.GetListAplicarProducts(User.Identity.GetUserId());
            return View(ViewBag.MiLista);
            
        }

        public ActionResult Detalle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Detalle(Donacion donacion)
        {

            return View();
        }

    }
}