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
    public class PlatilloVentasController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: PlatilloVentas
        public ActionResult Index()
        {
            var platilloVenta = db.PlatilloVenta.Include(p => p.Platillo).Include(p => p.Usuario).Include(p => p.Usuario1).Include(p => p.Venta);
            return View(platilloVenta.ToList());
        }

        // GET: PlatilloVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatilloVenta platilloVenta = db.PlatilloVenta.Find(id);
            if (platilloVenta == null)
            {
                return HttpNotFound();
            }
            return View(platilloVenta);
        }

        // GET: PlatilloVentas/Create
        public ActionResult Create()
        {
            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia");
            return View();
        }

        // POST: PlatilloVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlatilloVenta,idPlatillo,idVenta,cantidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PlatilloVenta platilloVenta)
        {
            if (ModelState.IsValid)
            {
                db.PlatilloVenta.Add(platilloVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre", platilloVenta.idPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platilloVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platilloVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", platilloVenta.idVenta);
            return View(platilloVenta);
        }

        // GET: PlatilloVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatilloVenta platilloVenta = db.PlatilloVenta.Find(id);
            if (platilloVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre", platilloVenta.idPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platilloVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platilloVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", platilloVenta.idVenta);
            return View(platilloVenta);
        }

        // POST: PlatilloVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlatilloVenta,idPlatillo,idVenta,cantidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PlatilloVenta platilloVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platilloVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre", platilloVenta.idPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platilloVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platilloVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "referencia", platilloVenta.idVenta);
            return View(platilloVenta);
        }

        // GET: PlatilloVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatilloVenta platilloVenta = db.PlatilloVenta.Find(id);
            if (platilloVenta == null)
            {
                return HttpNotFound();
            }
            return View(platilloVenta);
        }

        // POST: PlatilloVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatilloVenta platilloVenta = db.PlatilloVenta.Find(id);
            db.PlatilloVenta.Remove(platilloVenta);
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
