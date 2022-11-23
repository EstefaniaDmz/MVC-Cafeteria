using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeteriaTBD.Models;

namespace CafeteriaTBD.Controllers
{
    public class DevolucionVentasController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: DevolucionVentas
        public ActionResult Index()
        {
            var devolucionVenta = db.DevolucionVenta.Include(d => d.Usuario).Include(d => d.Usuario1).Include(d => d.Venta);
            return View(devolucionVenta.ToList());
        }

        // GET: DevolucionVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevolucionVenta devolucionVenta = db.DevolucionVenta.Find(id);
            if (devolucionVenta == null)
            {
                return HttpNotFound();
            }
            return View(devolucionVenta);
        }

        // GET: DevolucionVentas/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia");
            return View();
        }

        // POST: DevolucionVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDevolucionVenta,platillo,razon,cantidad,costo,idVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] DevolucionVenta devolucionVenta)
        {
            if (ModelState.IsValid)
            {
                db.DevolucionVenta.Add(devolucionVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", devolucionVenta.idVenta);
            return View(devolucionVenta);
        }

        // GET: DevolucionVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevolucionVenta devolucionVenta = db.DevolucionVenta.Find(id);
            if (devolucionVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", devolucionVenta.idVenta);
            return View(devolucionVenta);
        }

        // POST: DevolucionVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDevolucionVenta,platillo,razon,cantidad,costo,idVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] DevolucionVenta devolucionVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devolucionVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", devolucionVenta.idVenta);
            return View(devolucionVenta);
        }

        // GET: DevolucionVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevolucionVenta devolucionVenta = db.DevolucionVenta.Find(id);
            if (devolucionVenta == null)
            {
                return HttpNotFound();
            }
            return View(devolucionVenta);
        }

        // POST: DevolucionVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevolucionVenta devolucionVenta = db.DevolucionVenta.Find(id);
            db.DevolucionVenta.Remove(devolucionVenta);
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
