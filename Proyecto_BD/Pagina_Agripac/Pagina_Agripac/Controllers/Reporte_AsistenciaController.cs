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
    public class Reporte_AsistenciaController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Reporte_Asistencia
        public ActionResult Index()
        {
            var reporte_Asistencia = db.Reporte_Asistencia.Include(r => r.Empleado).Include(r => r.Motivo_Asistencia);
            return View(reporte_Asistencia.ToList());
        }

        // GET: Reporte_Asistencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte_Asistencia reporte_Asistencia = db.Reporte_Asistencia.Find(id);
            if (reporte_Asistencia == null)
            {
                return HttpNotFound();
            }
            return View(reporte_Asistencia);
        }

        // GET: Reporte_Asistencia/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre");
            ViewBag.idMotivo_Asistencia = new SelectList(db.Motivo_Asistencia, "idMotivo_Asistencia", "Motivo");
            return View();
        }

        // POST: Reporte_Asistencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asistencia,Comprobante,id_empleado,idMotivo_Asistencia,Fecha,Periodo")] Reporte_Asistencia reporte_Asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Reporte_Asistencia.Add(reporte_Asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", reporte_Asistencia.id_empleado);
            ViewBag.idMotivo_Asistencia = new SelectList(db.Motivo_Asistencia, "idMotivo_Asistencia", "Motivo", reporte_Asistencia.idMotivo_Asistencia);
            return View(reporte_Asistencia);
        }

        // GET: Reporte_Asistencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte_Asistencia reporte_Asistencia = db.Reporte_Asistencia.Find(id);
            if (reporte_Asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", reporte_Asistencia.id_empleado);
            ViewBag.idMotivo_Asistencia = new SelectList(db.Motivo_Asistencia, "idMotivo_Asistencia", "Motivo", reporte_Asistencia.idMotivo_Asistencia);
            return View(reporte_Asistencia);
        }

        // POST: Reporte_Asistencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asistencia,Comprobante,id_empleado,idMotivo_Asistencia,Fecha,Periodo")] Reporte_Asistencia reporte_Asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporte_Asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", reporte_Asistencia.id_empleado);
            ViewBag.idMotivo_Asistencia = new SelectList(db.Motivo_Asistencia, "idMotivo_Asistencia", "Motivo", reporte_Asistencia.idMotivo_Asistencia);
            return View(reporte_Asistencia);
        }

        // GET: Reporte_Asistencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte_Asistencia reporte_Asistencia = db.Reporte_Asistencia.Find(id);
            if (reporte_Asistencia == null)
            {
                return HttpNotFound();
            }
            return View(reporte_Asistencia);
        }

        // POST: Reporte_Asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reporte_Asistencia reporte_Asistencia = db.Reporte_Asistencia.Find(id);
            db.Reporte_Asistencia.Remove(reporte_Asistencia);
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
