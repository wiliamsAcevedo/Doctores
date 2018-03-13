using DOCTORESPAGINA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOCTORESPAGINA.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var InfoEntradas = db.Database.SqlQuery<Doctores>(@"Select DoctoresID, EspecialidadID, HospitalID, NombreDoc, Descripcion, EstadoDoc, FechaCreacionDoc
                                                                    From Doctores order by FechaCreacionDoc Desc").Take(10).ToList();

            return View(InfoEntradas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}