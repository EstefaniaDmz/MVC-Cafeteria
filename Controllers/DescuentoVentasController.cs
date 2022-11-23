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
    public class DescuentoVentasController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: DescuentoVentas
        public ActionResult Index()
        {
            var descuentoVenta = db.DescuentoVenta.Include(d => d.Descuento).Include(d => d.Usuario).Include(d => d.Usuario1).Include(d => d.Venta);
            return View(descuentoVenta.ToList());
        }

        // GET: DescuentoVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescuentoVenta descuentoVenta = db.DescuentoVenta.Find(id);
            if (descuentoVenta == null)
            {
                return HttpNotFound();
            }
            return View(descuentoVenta);
        }

        // GET: DescuentoVentas/Create
        public ActionResult Create()
        {
            ViewBag.idDescuento = new SelectList(db.Descuento, "idDescuento", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia");
            return View();
        }

        // POST: DescuentoVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDescuentoVenta,idDescuento,idVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] DescuentoVenta descuentoVenta)
        {
            if (ModelState.IsValid)
            {
                db.DescuentoVenta.Add(descuentoVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDescuento = new SelectList(db.Descuento, "idDescuento", "nombre", descuentoVenta.idDescuento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", descuentoVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", descuentoVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", descuentoVenta.idVenta);
            return View(descuentoVenta);
        }

        // GET: DescuentoVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescuentoVenta descuentoVenta = db.DescuentoVenta.Find(id);
            if (descuentoVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDescuento = new SelectList(db.Descuento, "idDescuento", "nombre", descuentoVenta.idDescuento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", descuentoVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", descuentoVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", descuentoVenta.idVenta);
            return View(descuentoVenta);
        }

        // POST: DescuentoVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDescuentoVenta,idDescuento,idVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] DescuentoVenta descuentoVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuentoVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDescuento = new SelectList(db.Descuento, "idDescuento", "nombre", descuentoVenta.idDescuento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", descuentoVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", descuentoVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", descuentoVenta.idVenta);
            return View(descuentoVenta);
        }

        // GET: DescuentoVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescuentoVenta descuentoVenta = db.DescuentoVenta.Find(id);
            if (descuentoVenta == null)
            {
                return HttpNotFound();
            }
            return View(descuentoVenta);
        }

        // POST: DescuentoVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DescuentoVenta descuentoVenta = db.DescuentoVenta.Find(id);
            db.DescuentoVenta.Remove(descuentoVenta);
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
