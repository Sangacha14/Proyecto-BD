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
    public class Cabecera_NominaController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Cabecera_Nomina
        public ActionResult Index()
        {
            var cabecera_Nomina = db.Cabecera_Nomina.Include(c => c.Empleado).Include(c => c.Sueldo);
            return View(cabecera_Nomina.ToList());
        }

        // GET: Cabecera_Nomina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabecera_Nomina cabecera_Nomina = db.Cabecera_Nomina.Find(id);
            if (cabecera_Nomina == null)
            {
                return HttpNotFound();
            }
            return View(cabecera_Nomina);
        }

        // GET: Cabecera_Nomina/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre");
            ViewBag.idSueldo = new SelectList(db.Sueldo, "idSueldo", "idSueldo");
            return View();
        }

        // POST: Cabecera_Nomina/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Nomina,Comprobante,id_empleado,idSueldo,Iess_por,Fecha,Periodo")] Cabecera_Nomina cabecera_Nomina)
        {
            if (ModelState.IsValid)
            {
                db.Cabecera_Nomina.Add(cabecera_Nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", cabecera_Nomina.id_empleado);
            ViewBag.idSueldo = new SelectList(db.Sueldo, "idSueldo", "idSueldo", cabecera_Nomina.idSueldo);
            return View(cabecera_Nomina);
        }

        // GET: Cabecera_Nomina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabecera_Nomina cabecera_Nomina = db.Cabecera_Nomina.Find(id);
            if (cabecera_Nomina == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", cabecera_Nomina.id_empleado);
            ViewBag.idSueldo = new SelectList(db.Sueldo, "idSueldo", "idSueldo", cabecera_Nomina.idSueldo);
            return View(cabecera_Nomina);
        }

        // POST: Cabecera_Nomina/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Nomina,Comprobante,id_empleado,idSueldo,Iess_por,Fecha,Periodo")] Cabecera_Nomina cabecera_Nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cabecera_Nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", cabecera_Nomina.id_empleado);
            ViewBag.idSueldo = new SelectList(db.Sueldo, "idSueldo", "idSueldo", cabecera_Nomina.idSueldo);
            return View(cabecera_Nomina);
        }

        // GET: Cabecera_Nomina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cabecera_Nomina cabecera_Nomina = db.Cabecera_Nomina.Find(id);
            if (cabecera_Nomina == null)
            {
                return HttpNotFound();
            }
            return View(cabecera_Nomina);
        }

        // POST: Cabecera_Nomina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cabecera_Nomina cabecera_Nomina = db.Cabecera_Nomina.Find(id);
            db.Cabecera_Nomina.Remove(cabecera_Nomina);
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
