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
    public class VentasController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.Cliente).Include(v => v.CorteVenta).Include(v => v.Sucursal).Include(v => v.Usuario).Include(v => v.Usuario1);
            return View(venta.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            ViewBag.idCorteVenta = new SelectList(db.CorteVenta, "idCorteVenta", "caja");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,referencia,fecha,precio,idSucursal,idCliente,idCorteVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", venta.idCliente);
            ViewBag.idCorteVenta = new SelectList(db.CorteVenta, "idCorteVenta", "caja", venta.idCorteVenta);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", venta.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioModifica);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", venta.idCliente);
            ViewBag.idCorteVenta = new SelectList(db.CorteVenta, "idCorteVenta", "caja", venta.idCorteVenta);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", venta.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioModifica);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,referencia,fecha,precio,idSucursal,idCliente,idCorteVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", venta.idCliente);
            ViewBag.idCorteVenta = new SelectList(db.CorteVenta, "idCorteVenta", "caja", venta.idCorteVenta);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", venta.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioModifica);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
