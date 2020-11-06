using Microsoft.AspNet.Identity;
using PrestoFolder;
using SharedFood.Common;
using SharedFood.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SharedFood.Controllers
{
    public class DonacionController : Controller
    {
        // GET: Donacion
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Donacion donacion)
        {
            try
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(donacion.postedFile.InputStream))
                {
                    bytes = br.ReadBytes(donacion.postedFile.ContentLength);
                }

                donacion.Image = bytes;
                donacion.IdUsuarioCreacion = User.Identity.GetUserId();
                donacion.Radio = 0;
                donacion.IdEstado = Convert.ToInt32(Enums.Estado.Disponible);

                MyBusiness.Donacion.Insertar(donacion);
               // return View("Index", "Home");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar Controller:Donacion; Method: Index", ex);
                ExceptionManager.HandleException(e, 1, 5000, 1);
                TempData["msg"] = MyMessage.Error("Ha ocurrido un error inesperado por favor contacte el administrador del sistema!");
            }
            return View();
        }
    }
}