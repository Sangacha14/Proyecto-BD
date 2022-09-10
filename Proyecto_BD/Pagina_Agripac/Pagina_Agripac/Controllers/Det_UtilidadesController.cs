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
    public class Det_UtilidadesController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Det_Utilidades
        public ActionResult Index()
        {
            var det_Utilidades = db.Det_Utilidades.Include(d => d.Utilidades);
            return View(det_Utilidades.ToList());
        }

        // GET: Det_Utilidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Utilidades det_Utilidades = db.Det_Utilidades.Find(id);
            if (det_Utilidades == null)
            {
                return HttpNotFound();
            }
            return View(det_Utilidades);
        }

        // GET: Det_Utilidades/Create
        public ActionResult Create()
        {
            ViewBag.id_utilidades = new SelectList(db.Utilidades, "id_utilidades", "Comprobante");
            return View();
        }

        // POST: Det_Utilidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_det_utilidades,id_utilidades,Descripcion,Carga_Familiar,Dias_laborados")] Det_Utilidades det_Utilidades)
        {
            if (ModelState.IsValid)
            {
                db.Det_Utilidades.Add(det_Utilidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_utilidades = new SelectList(db.Utilidades, "id_utilidades", "Comprobante", det_Utilidades.id_utilidades);
            return View(det_Utilidades);
        }

        // GET: Det_Utilidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Utilidades det_Utilidades = db.Det_Utilidades.Find(id);
            if (det_Utilidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_utilidades = new SelectList(db.Utilidades, "id_utilidades", "Comprobante", det_Utilidades.id_utilidades);
            return View(det_Utilidades);
        }

        // POST: Det_Utilidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_det_utilidades,id_utilidades,Descripcion,Carga_Familiar,Dias_laborados")] Det_Utilidades det_Utilidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(det_Utilidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_utilidades = new SelectList(db.Utilidades, "id_utilidades", "Comprobante", det_Utilidades.id_utilidades);
            return View(det_Utilidades);
        }

        // GET: Det_Utilidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Utilidades det_Utilidades = db.Det_Utilidades.Find(id);
            if (det_Utilidades == null)
            {
                return HttpNotFound();
            }
            return View(det_Utilidades);
        }

        // POST: Det_Utilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Det_Utilidades det_Utilidades = db.Det_Utilidades.Find(id);
            db.Det_Utilidades.Remove(det_Utilidades);
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
