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
    public class DevolucionComprasController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: DevolucionCompras
        public ActionResult Index()
        {
            var devolucionCompra = db.DevolucionCompra.Include(d => d.Compra).Include(d => d.Usuario).Include(d => d.Usuario1);
            return View(devolucionCompra.ToList());
        }

        // GET: DevolucionCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevolucionCompra devolucionCompra = db.DevolucionCompra.Find(id);
            if (devolucionCompra == null)
            {
                return HttpNotFound();
            }
            return View(devolucionCompra);
        }

        // GET: DevolucionCompras/Create
        public ActionResult Create()
        {
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: DevolucionCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDevolucionCompra,platillo,razon,cantidad,costo,idCompra,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] DevolucionCompra devolucionCompra)
        {
            if (ModelState.IsValid)
            {
                db.DevolucionCompra.Add(devolucionCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia", devolucionCompra.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionCompra.idUsuarioModifica);
            return View(devolucionCompra);
        }

        // GET: DevolucionCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevolucionCompra devolucionCompra = db.DevolucionCompra.Find(id);
            if (devolucionCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia", devolucionCompra.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionCompra.idUsuarioModifica);
            return View(devolucionCompra);
        }

        // POST: DevolucionCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDevolucionCompra,platillo,razon,cantidad,costo,idCompra,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] DevolucionCompra devolucionCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devolucionCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia", devolucionCompra.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", devolucionCompra.idUsuarioModifica);
            return View(devolucionCompra);
        }

        // GET: DevolucionCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevolucionCompra devolucionCompra = db.DevolucionCompra.Find(id);
            if (devolucionCompra == null)
            {
                return HttpNotFound();
            }
            return View(devolucionCompra);
        }

        // POST: DevolucionCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevolucionCompra devolucionCompra = db.DevolucionCompra.Find(id);
            db.DevolucionCompra.Remove(devolucionCompra);
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
