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
    public class SueldoesController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Sueldoes
        public ActionResult Index()
        {
            var sueldo = db.Sueldo.Include(s => s.Cargo);
            return View(sueldo.ToList());
        }

        // GET: Sueldoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sueldo sueldo = db.Sueldo.Find(id);
            if (sueldo == null)
            {
                return HttpNotFound();
            }
            return View(sueldo);
        }

        // GET: Sueldoes/Create
        public ActionResult Create()
        {
            ViewBag.id_cargo = new SelectList(db.Cargo, "id_cargo", "Cargo1");
            return View();
        }

        // POST: Sueldoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSueldo,id_cargo,Sueldo1")] Sueldo sueldo)
        {
            if (ModelState.IsValid)
            {
                db.Sueldo.Add(sueldo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cargo = new SelectList(db.Cargo, "id_cargo", "Cargo1", sueldo.id_cargo);
            return View(sueldo);
        }

        // GET: Sueldoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sueldo sueldo = db.Sueldo.Find(id);
            if (sueldo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cargo = new SelectList(db.Cargo, "id_cargo", "Cargo1", sueldo.id_cargo);
            return View(sueldo);
        }

        // POST: Sueldoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSueldo,id_cargo,Sueldo1")] Sueldo sueldo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sueldo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cargo = new SelectList(db.Cargo, "id_cargo", "Cargo1", sueldo.id_cargo);
            return View(sueldo);
        }

        // GET: Sueldoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sueldo sueldo = db.Sueldo.Find(id);
            if (sueldo == null)
            {
                return HttpNotFound();
            }
            return View(sueldo);
        }

        // POST: Sueldoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sueldo sueldo = db.Sueldo.Find(id);
            db.Sueldo.Remove(sueldo);
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
