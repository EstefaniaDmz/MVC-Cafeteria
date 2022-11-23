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
    public class SucursalsController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Sucursals
        public ActionResult Index()
        {
            var sucursal = db.Sucursal.Include(s => s.Asentamiento).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursal.ToList());
        }

        // GET: Sucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // GET: Sucursals/Create
        public ActionResult Create()
        {
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Sucursals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursal,nombre,telefono,calle,idAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Sucursal.Add(sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre", sucursal.idAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursal.idUsuarioModifica);
            return View(sucursal);
        }

        // GET: Sucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre", sucursal.idAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursal.idUsuarioModifica);
            return View(sucursal);
        }

        // POST: Sucursals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursal,nombre,telefono,calle,idAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre", sucursal.idAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursal.idUsuarioModifica);
            return View(sucursal);
        }

        // GET: Sucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // POST: Sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucursal sucursal = db.Sucursal.Find(id);
            db.Sucursal.Remove(sucursal);
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
