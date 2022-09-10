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
    public class DETALLE_NOMINAController : Controller
    {
        private AgripacEntities db = new AgripacEntities();

        // GET: DETALLE_NOMINA
        public ActionResult Index()
        {
            var dETALLE_NOMINA = db.DETALLE_NOMINA.Include(d => d.Cabecera_Nomina).Include(d => d.Empleado);
            return View(dETALLE_NOMINA.ToList());
        }

        // GET: DETALLE_NOMINA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_NOMINA dETALLE_NOMINA = db.DETALLE_NOMINA.Find(id);
            if (dETALLE_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_NOMINA);
        }

        // GET: DETALLE_NOMINA/Create
        public ActionResult Create()
        {
            ViewBag.id_Nomina = new SelectList(db.Cabecera_Nomina, "id_Nomina", "Comprobante");
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre");
            return View();
        }

        // POST: DETALLE_NOMINA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_det_nomina,id_Nomina,id_empleado,Fecha,Periodo")] DETALLE_NOMINA dETALLE_NOMINA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_NOMINA.Add(dETALLE_NOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Nomina = new SelectList(db.Cabecera_Nomina, "id_Nomina", "Comprobante", dETALLE_NOMINA.id_Nomina);
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", dETALLE_NOMINA.id_empleado);
            return View(dETALLE_NOMINA);
        }

        // GET: DETALLE_NOMINA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_NOMINA dETALLE_NOMINA = db.DETALLE_NOMINA.Find(id);
            if (dETALLE_NOMINA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Nomina = new SelectList(db.Cabecera_Nomina, "id_Nomina", "Comprobante", dETALLE_NOMINA.id_Nomina);
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", dETALLE_NOMINA.id_empleado);
            return View(dETALLE_NOMINA);
        }

        // POST: DETALLE_NOMINA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_det_nomina,id_Nomina,id_empleado,Fecha,Periodo")] DETALLE_NOMINA dETALLE_NOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_NOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Nomina = new SelectList(db.Cabecera_Nomina, "id_Nomina", "Comprobante", dETALLE_NOMINA.id_Nomina);
            ViewBag.id_empleado = new SelectList(db.Empleado, "id_empleado", "Nombre", dETALLE_NOMINA.id_empleado);
            return View(dETALLE_NOMINA);
        }

        // GET: DETALLE_NOMINA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_NOMINA dETALLE_NOMINA = db.DETALLE_NOMINA.Find(id);
            if (dETALLE_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_NOMINA);
        }

        // POST: DETALLE_NOMINA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_NOMINA dETALLE_NOMINA = db.DETALLE_NOMINA.Find(id);
            db.DETALLE_NOMINA.Remove(dETALLE_NOMINA);
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
