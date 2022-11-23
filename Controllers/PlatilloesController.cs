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
    public class PlatilloesController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Platilloes
        public ActionResult Index()
        {
            var platillo = db.Platillo.Include(p => p.TipoPlatillo).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(platillo.ToList());
        }

        // GET: Platilloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platillo platillo = db.Platillo.Find(id);
            if (platillo == null)
            {
                return HttpNotFound();
            }
            return View(platillo);
        }

        // GET: Platilloes/Create
        public ActionResult Create()
        {
            ViewBag.idTipoPlatillo = new SelectList(db.TipoPlatillo, "idTipoPlatillo", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Platilloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlatillo,nombre,descripcion,costo,idTipoPlatillo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Platillo platillo)
        {
            if (ModelState.IsValid)
            {
                db.Platillo.Add(platillo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoPlatillo = new SelectList(db.TipoPlatillo, "idTipoPlatillo", "nombre", platillo.idTipoPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platillo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platillo.idUsuarioModifica);
            return View(platillo);
        }

        // GET: Platilloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platillo platillo = db.Platillo.Find(id);
            if (platillo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoPlatillo = new SelectList(db.TipoPlatillo, "idTipoPlatillo", "nombre", platillo.idTipoPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platillo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platillo.idUsuarioModifica);
            return View(platillo);
        }

        // POST: Platilloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlatillo,nombre,descripcion,costo,idTipoPlatillo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Platillo platillo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platillo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoPlatillo = new SelectList(db.TipoPlatillo, "idTipoPlatillo", "nombre", platillo.idTipoPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platillo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platillo.idUsuarioModifica);
            return View(platillo);
        }

        // GET: Platilloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platillo platillo = db.Platillo.Find(id);
            if (platillo == null)
            {
                return HttpNotFound();
            }
            return View(platillo);
        }

        // POST: Platilloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Platillo platillo = db.Platillo.Find(id);
            db.Platillo.Remove(platillo);
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
