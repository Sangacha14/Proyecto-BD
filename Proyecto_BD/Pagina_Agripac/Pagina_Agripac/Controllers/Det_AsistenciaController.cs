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
    public class Det_AsistenciaController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Det_Asistencia
        public ActionResult Index()
        {
            var det_Asistencia = db.Det_Asistencia.Include(d => d.Reporte_Asistencia);
            return View(det_Asistencia.ToList());
        }

        // GET: Det_Asistencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Asistencia det_Asistencia = db.Det_Asistencia.Find(id);
            if (det_Asistencia == null)
            {
                return HttpNotFound();
            }
            return View(det_Asistencia);
        }

        // GET: Det_Asistencia/Create
        public ActionResult Create()
        {
            ViewBag.id_asistencia = new SelectList(db.Reporte_Asistencia, "id_asistencia", "Comprobante");
            return View();
        }

        // POST: Det_Asistencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_det_asistencia,id_asistencia,Mes_Completo,Dias_Inasistidos")] Det_Asistencia det_Asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Det_Asistencia.Add(det_Asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_asistencia = new SelectList(db.Reporte_Asistencia, "id_asistencia", "Comprobante", det_Asistencia.id_asistencia);
            return View(det_Asistencia);
        }

        // GET: Det_Asistencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Asistencia det_Asistencia = db.Det_Asistencia.Find(id);
            if (det_Asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_asistencia = new SelectList(db.Reporte_Asistencia, "id_asistencia", "Comprobante", det_Asistencia.id_asistencia);
            return View(det_Asistencia);
        }

        // POST: Det_Asistencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_det_asistencia,id_asistencia,Mes_Completo,Dias_Inasistidos")] Det_Asistencia det_Asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(det_Asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_asistencia = new SelectList(db.Reporte_Asistencia, "id_asistencia", "Comprobante", det_Asistencia.id_asistencia);
            return View(det_Asistencia);
        }

        // GET: Det_Asistencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Asistencia det_Asistencia = db.Det_Asistencia.Find(id);
            if (det_Asistencia == null)
            {
                return HttpNotFound();
            }
            return View(det_Asistencia);
        }

        // POST: Det_Asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Det_Asistencia det_Asistencia = db.Det_Asistencia.Find(id);
            db.Det_Asistencia.Remove(det_Asistencia);
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
