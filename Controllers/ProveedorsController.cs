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
    public class ProveedorsController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Proveedors
        public ActionResult Index()
        {
            var proveedor = db.Proveedor.Include(p => p.Asentamiento).Include(p => p.TipoProveedor).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(proveedor.ToList());
        }

        // GET: Proveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedors/Create
        public ActionResult Create()
        {
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre");
            ViewBag.idTipoProveedor = new SelectList(db.TipoProveedor, "idTipoProveedor", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedor,nombre,apellidoMaterno,apellidoPaterno,rfc,telefono,correo,idTipoProveedor,idAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre", proveedor.idAsentamiento);
            ViewBag.idTipoProveedor = new SelectList(db.TipoProveedor, "idTipoProveedor", "nombre", proveedor.idTipoProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", proveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", proveedor.idUsuarioModifica);
            return View(proveedor);
        }

        // GET: Proveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre", proveedor.idAsentamiento);
            ViewBag.idTipoProveedor = new SelectList(db.TipoProveedor, "idTipoProveedor", "nombre", proveedor.idTipoProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", proveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", proveedor.idUsuarioModifica);
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedor,nombre,apellidoMaterno,apellidoPaterno,rfc,telefono,correo,idTipoProveedor,idAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "nombre", proveedor.idAsentamiento);
            ViewBag.idTipoProveedor = new SelectList(db.TipoProveedor, "idTipoProveedor", "nombre", proveedor.idTipoProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", proveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", proveedor.idUsuarioModifica);
            return View(proveedor);
        }

        // GET: Proveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            db.Proveedor.Remove(proveedor);
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
