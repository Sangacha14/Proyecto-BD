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
    public class UtilidadesController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: Utilidades
        public ActionResult Index()
        {
            var utilidades = db.Utilidades.Include(u => u.Empleado);
            return View(utilidades.ToList());
        }

        // GET: Utilidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilidades utilidades = db.Utilidades.Find(id);
            if (utilidades == null)
            {
                return HttpNotFound();
            }
            return View(utilidades);
        }

        // GET: Utilidades/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre");
            return View();
        }

        // POST: Utilidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_utilidades,Comprobante,id_empleado,Fecha,Valor_Utilidades,Fecha_pago,Anio")] Utilidades utilidades)
        {
            if (ModelState.IsValid)
            {
                db.Utilidades.Add(utilidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", utilidades.id_empleado);
            return View(utilidades);
        }

        // GET: Utilidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilidades utilidades = db.Utilidades.Find(id);
            if (utilidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", utilidades.id_empleado);
            return View(utilidades);
        }

        // POST: Utilidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_utilidades,Comprobante,id_empleado,Fecha,Valor_Utilidades,Fecha_pago,Anio")] Utilidades utilidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", utilidades.id_empleado);
            return View(utilidades);
        }

        // GET: Utilidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilidades utilidades = db.Utilidades.Find(id);
            if (utilidades == null)
            {
                return HttpNotFound();
            }
            return View(utilidades);
        }

        // POST: Utilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilidades utilidades = db.Utilidades.Find(id);
            db.Utilidades.Remove(utilidades);
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
