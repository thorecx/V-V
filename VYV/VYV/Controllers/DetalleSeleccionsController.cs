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
    public class DetalleSeleccionsController : Controller
    {
        private VyVDbContext db = new VyVDbContext();

        // GET: DetalleSeleccions
        public ActionResult Index()
        {
            var detalleSeleccion = db.DetalleSeleccion.Include(d => d.Asignatura).Include(d => d.Estudiante).Include(d => d.Grupo).Include(d => d.Profesor);
            return View(detalleSeleccion.ToList());
        }

        // GET: DetalleSeleccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSeleccion detalleSeleccion = db.DetalleSeleccion.Find(id);
            if (detalleSeleccion == null)
            {
                return HttpNotFound();
            }
            return View(detalleSeleccion);
        }

        // GET: DetalleSeleccions/Create
        public ActionResult Create()
        {
            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion");
            ViewBag.CodEstudiante = new SelectList(db.Estudiante, "CodEstudiante", "Cedula");
            ViewBag.CodGrupo = new SelectList(db.Grupo, "CodGrupo", "Ubicacion");
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula");
            return View();
        }

        // POST: DetalleSeleccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodDetalle,CodEstudiante,CodAsignatura,CodProfesor,CodGrupo,Fecha,Estatus")] DetalleSeleccion detalleSeleccion)
        {
            if (ModelState.IsValid)
            {
                db.DetalleSeleccion.Add(detalleSeleccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion", detalleSeleccion.CodAsignatura);
            ViewBag.CodEstudiante = new SelectList(db.Estudiante, "CodEstudiante", "Cedula", detalleSeleccion.CodEstudiante);
            ViewBag.CodGrupo = new SelectList(db.Grupo, "CodGrupo", "Ubicacion", detalleSeleccion.CodGrupo);
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula", detalleSeleccion.CodProfesor);
            return View(detalleSeleccion);
        }

        // GET: DetalleSeleccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSeleccion detalleSeleccion = db.DetalleSeleccion.Find(id);
            if (detalleSeleccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion", detalleSeleccion.CodAsignatura);
            ViewBag.CodEstudiante = new SelectList(db.Estudiante, "CodEstudiante", "Cedula", detalleSeleccion.CodEstudiante);
            ViewBag.CodGrupo = new SelectList(db.Grupo, "CodGrupo", "Ubicacion", detalleSeleccion.CodGrupo);
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula", detalleSeleccion.CodProfesor);
            return View(detalleSeleccion);
        }

        // POST: DetalleSeleccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodDetalle,CodEstudiante,CodAsignatura,CodProfesor,CodGrupo,Fecha,Estatus")] DetalleSeleccion detalleSeleccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleSeleccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodAsignatura = new SelectList(db.Asignatura, "CodAsignatura", "Descripcion", detalleSeleccion.CodAsignatura);
            ViewBag.CodEstudiante = new SelectList(db.Estudiante, "CodEstudiante", "Cedula", detalleSeleccion.CodEstudiante);
            ViewBag.CodGrupo = new SelectList(db.Grupo, "CodGrupo", "Ubicacion", detalleSeleccion.CodGrupo);
            ViewBag.CodProfesor = new SelectList(db.Profesor, "CodProfesor", "Cedula", detalleSeleccion.CodProfesor);
            return View(detalleSeleccion);
        }

        // GET: DetalleSeleccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleSeleccion detalleSeleccion = db.DetalleSeleccion.Find(id);
            if (detalleSeleccion == null)
            {
                return HttpNotFound();
            }
            return View(detalleSeleccion);
        }

        // POST: DetalleSeleccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleSeleccion detalleSeleccion = db.DetalleSeleccion.Find(id);
            db.DetalleSeleccion.Remove(detalleSeleccion);
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
