using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ViewBag.MiLista = MyBusiness.Donacion.GetList(User.Identity.GetUserId()).OrderByDescending(C => C.fechaCreacion);
            }
            catch (Exception ex)
            {

                throw;
            }
            
           
            return View(ViewBag.MiLista);
        }
    }
}