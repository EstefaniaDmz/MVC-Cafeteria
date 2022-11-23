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
    public class CorteVentasController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: CorteVentas
        public ActionResult Index()
        {
            var corteVenta = db.CorteVenta.Include(c => c.Trabajador).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(corteVenta.ToList());
        }

        // GET: CorteVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorteVenta corteVenta = db.CorteVenta.Find(id);
            if (corteVenta == null)
            {
                return HttpNotFound();
            }
            return View(corteVenta);
        }

        // GET: CorteVentas/Create
        public ActionResult Create()
        {
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: CorteVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCorteVenta,caja,fecha,venta,gasto,tarjeta,idTrabajador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] CorteVenta corteVenta)
        {
            if (ModelState.IsValid)
            {
                db.CorteVenta.Add(corteVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", corteVenta.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", corteVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", corteVenta.idUsuarioModifica);
            return View(corteVenta);
        }

        // GET: CorteVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorteVenta corteVenta = db.CorteVenta.Find(id);
            if (corteVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", corteVenta.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", corteVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", corteVenta.idUsuarioModifica);
            return View(corteVenta);
        }

        // POST: CorteVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCorteVenta,caja,fecha,venta,gasto,tarjeta,idTrabajador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] CorteVenta corteVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corteVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", corteVenta.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", corteVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", corteVenta.idUsuarioModifica);
            return View(corteVenta);
        }

        // GET: CorteVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorteVenta corteVenta = db.CorteVenta.Find(id);
            if (corteVenta == null)
            {
                return HttpNotFound();
            }
            return View(corteVenta);
        }

        // POST: CorteVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CorteVenta corteVenta = db.CorteVenta.Find(id);
            db.CorteVenta.Remove(corteVenta);
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
