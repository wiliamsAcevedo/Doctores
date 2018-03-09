using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOCTORESPAGINA.Models;

namespace DOCTORESPAGINA.Controllers
{
    public class DoctoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctores
        public ActionResult Index()
        {
            var doctores = db.Doctores.Include(d => d.Especialidades).Include(d => d.Hospitales);
            return View(doctores.ToList());
        }

        // GET: Doctores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctores = db.Doctores.Find(id);
            if (doctores == null)
            {
                return HttpNotFound();
            }
            return View(doctores);
        }

        // GET: Doctores/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadID = new SelectList(db.Especialidads, "EspecialidadID", "NombreEsp");
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "NombreHosp");
            return View();
        }

        // POST: Doctores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctoresID,EspecialidadID,HospitalID,NombreDoc,Descripcion,EstadoDoc")] Doctores doctores)
        {
            if (ModelState.IsValid)
            {
                db.Doctores.Add(doctores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadID = new SelectList(db.Especialidads, "EspecialidadID", "NombreEsp", doctores.EspecialidadID);
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "NombreHosp", doctores.HospitalID);
            return View(doctores);
        }

        // GET: Doctores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctores = db.Doctores.Find(id);
            if (doctores == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadID = new SelectList(db.Especialidads, "EspecialidadID", "NombreEsp", doctores.EspecialidadID);
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "NombreHosp", doctores.HospitalID);
            return View(doctores);
        }

        // POST: Doctores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctoresID,EspecialidadID,HospitalID,NombreDoc,Descripcion,EstadoDoc")] Doctores doctores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadID = new SelectList(db.Especialidads, "EspecialidadID", "NombreEsp", doctores.EspecialidadID);
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "NombreHosp", doctores.HospitalID);
            return View(doctores);
        }

        // GET: Doctores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctores = db.Doctores.Find(id);
            if (doctores == null)
            {
                return HttpNotFound();
            }
            return View(doctores);
        }

        // POST: Doctores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctores doctores = db.Doctores.Find(id);
            db.Doctores.Remove(doctores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
