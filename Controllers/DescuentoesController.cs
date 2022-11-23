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
    public class DescuentoesController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Descuentoes
        public ActionResult Index()
        {
            var descuento = db.Descuento.Include(d => d.Usuario).Include(d => d.Usuario1);
            return View(descuento.ToList());
        }

        // GET: Descuentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // GET: Descuentoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Descuentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDescuento,nombre,descripcion,porcentaje,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Descuento.Add(descuento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", descuento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", descuento.idUsuarioModifica);
            return View(descuento);
        }

        // GET: Descuentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", descuento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", descuento.idUsuarioModifica);
            return View(descuento);
        }

        // POST: Descuentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDescuento,nombre,descripcion,porcentaje,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", descuento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", descuento.idUsuarioModifica);
            return View(descuento);
        }

        // GET: Descuentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // POST: Descuentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Descuento descuento = db.Descuento.Find(id);
            db.Descuento.Remove(descuento);
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
