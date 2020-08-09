using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VYV;

namespace VYV.Controllers
{
    public class AsigProfesorsController : Controller
    {
        private VyVDbContext db = new VyVDbContext();

        // GET: AsigProfesors
        public ActionResult Index()
        {
            var asigProfesor = db.AsigProfesor.Include(a => a.Asignatura).Include(a => a.Profesor);
            return View(asigProfesor.ToList());
        }

        // GET: AsigProfesors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigProfesor asigProfesor = db.AsigProfesor.Find(id);
            if (asigProfesor == null)
            {
                return HttpNotFound();
            }
            return View(asigProfesor);
        }

        // GET: AsigProfesors/Create
        public ActionResult Create()
        {
            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion");
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula");
            return View();
        }

        // POST: AsigProfesors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodAsigProf,CodAsignatura,CodProfesor,Fecha")] AsigProfesor asigProfesor)
        {
            if (ModelState.IsValid)
            {
                db.AsigProfesor.Add(asigProfesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion", asigProfesor.CodAsignatura);
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula", asigProfesor.CodProfesor);
            return View(asigProfesor);
        }

        // GET: AsigProfesors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigProfesor asigProfesor = db.AsigProfesor.Find(id);
            if (asigProfesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion", asigProfesor.CodAsignatura);
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula", asigProfesor.CodProfesor);
            return View(asigProfesor);
        }

        // POST: AsigProfesors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodAsigProf,CodAsignatura,CodProfesor,Fecha")] AsigProfesor asigProfesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asigProfesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion", asigProfesor.CodAsignatura);
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula", asigProfesor.CodProfesor);
            return View(asigProfesor);
        }

        // GET: AsigProfesors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsigProfesor asigProfesor = db.AsigProfesor.Find(id);
            if (asigProfesor == null)
            {
                return HttpNotFound();
            }
            return View(asigProfesor);
        }

        // POST: AsigProfesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsigProfesor asigProfesor = db.AsigProfesor.Find(id);
            db.AsigProfesor.Remove(asigProfesor);
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
