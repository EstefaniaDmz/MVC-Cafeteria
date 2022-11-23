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
    public class TipoPlatilloesController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: TipoPlatilloes
        public ActionResult Index()
        {
            var tipoPlatillo = db.TipoPlatillo.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoPlatillo.ToList());
        }

        // GET: TipoPlatilloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlatillo tipoPlatillo = db.TipoPlatillo.Find(id);
            if (tipoPlatillo == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlatillo);
        }

        // GET: TipoPlatilloes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoPlatilloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoPlatillo,nombre,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoPlatillo tipoPlatillo)
        {
            if (ModelState.IsValid)
            {
                db.TipoPlatillo.Add(tipoPlatillo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoPlatillo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoPlatillo.idUsuarioModifica);
            return View(tipoPlatillo);
        }

        // GET: TipoPlatilloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlatillo tipoPlatillo = db.TipoPlatillo.Find(id);
            if (tipoPlatillo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoPlatillo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoPlatillo.idUsuarioModifica);
            return View(tipoPlatillo);
        }

        // POST: TipoPlatilloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoPlatillo,nombre,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoPlatillo tipoPlatillo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPlatillo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoPlatillo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoPlatillo.idUsuarioModifica);
            return View(tipoPlatillo);
        }

        // GET: TipoPlatilloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlatillo tipoPlatillo = db.TipoPlatillo.Find(id);
            if (tipoPlatillo == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlatillo);
        }

        // POST: TipoPlatilloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPlatillo tipoPlatillo = db.TipoPlatillo.Find(id);
            db.TipoPlatillo.Remove(tipoPlatillo);
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
