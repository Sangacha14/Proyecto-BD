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
    public class Det_HorarioController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Det_Horario
        public ActionResult Index()
        {
            var det_Horario = db.Det_Horario.Include(d => d.Horario).Include(d => d.Jornada);
            return View(det_Horario.ToList());
        }

        // GET: Det_Horario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Horario det_Horario = db.Det_Horario.Find(id);
            if (det_Horario == null)
            {
                return HttpNotFound();
            }
            return View(det_Horario);
        }

        // GET: Det_Horario/Create
        public ActionResult Create()
        {
            ViewBag.id_horario = new SelectList(db.Horario, "id_horario", "Comprobante");
            ViewBag.id_jornada = new SelectList(db.Jornada, "id_jornada", "Jornada1");
            return View();
        }

        // POST: Det_Horario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_det_horario,id_horario,id_jornada,Fecha_inicial,Fecha_final")] Det_Horario det_Horario)
        {
            if (ModelState.IsValid)
            {
                db.Det_Horario.Add(det_Horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_horario = new SelectList(db.Horario, "id_horario", "Comprobante", det_Horario.id_horario);
            ViewBag.id_jornada = new SelectList(db.Jornada, "id_jornada", "Jornada1", det_Horario.id_jornada);
            return View(det_Horario);
        }

        // GET: Det_Horario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Horario det_Horario = db.Det_Horario.Find(id);
            if (det_Horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_horario = new SelectList(db.Horario, "id_horario", "Comprobante", det_Horario.id_horario);
            ViewBag.id_jornada = new SelectList(db.Jornada, "id_jornada", "Jornada1", det_Horario.id_jornada);
            return View(det_Horario);
        }

        // POST: Det_Horario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_det_horario,id_horario,id_jornada,Fecha_inicial,Fecha_final")] Det_Horario det_Horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(det_Horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_horario = new SelectList(db.Horario, "id_horario", "Comprobante", det_Horario.id_horario);
            ViewBag.id_jornada = new SelectList(db.Jornada, "id_jornada", "Jornada1", det_Horario.id_jornada);
            return View(det_Horario);
        }

        // GET: Det_Horario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Det_Horario det_Horario = db.Det_Horario.Find(id);
            if (det_Horario == null)
            {
                return HttpNotFound();
            }
            return View(det_Horario);
        }

        // POST: Det_Horario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Det_Horario det_Horario = db.Det_Horario.Find(id);
            db.Det_Horario.Remove(det_Horario);
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
