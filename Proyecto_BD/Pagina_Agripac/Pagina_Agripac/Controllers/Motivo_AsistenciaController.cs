using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pagina_Agripac;

namespace Pagina_Agripac.Controllers
{
    public class Motivo_AsistenciaController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Motivo_Asistencia
        public ActionResult Index()
        {
            return View(db.Motivo_Asistencia.ToList());
        }

        // GET: Motivo_Asistencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Asistencia motivo_Asistencia = db.Motivo_Asistencia.Find(id);
            if (motivo_Asistencia == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Asistencia);
        }

        // GET: Motivo_Asistencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motivo_Asistencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMotivo_Asistencia,Motivo")] Motivo_Asistencia motivo_Asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Motivo_Asistencia.Add(motivo_Asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motivo_Asistencia);
        }

        // GET: Motivo_Asistencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Asistencia motivo_Asistencia = db.Motivo_Asistencia.Find(id);
            if (motivo_Asistencia == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Asistencia);
        }

        // POST: Motivo_Asistencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMotivo_Asistencia,Motivo")] Motivo_Asistencia motivo_Asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motivo_Asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motivo_Asistencia);
        }

        // GET: Motivo_Asistencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motivo_Asistencia motivo_Asistencia = db.Motivo_Asistencia.Find(id);
            if (motivo_Asistencia == null)
            {
                return HttpNotFound();
            }
            return View(motivo_Asistencia);
        }

        // POST: Motivo_Asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motivo_Asistencia motivo_Asistencia = db.Motivo_Asistencia.Find(id);
            db.Motivo_Asistencia.Remove(motivo_Asistencia);
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
