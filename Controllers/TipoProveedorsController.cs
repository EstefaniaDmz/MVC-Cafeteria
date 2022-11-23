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
    public class TipoProveedorsController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: TipoProveedors
        public ActionResult Index()
        {
            var tipoProveedor = db.TipoProveedor.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoProveedor.ToList());
        }

        // GET: TipoProveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            if (tipoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoProveedor);
        }

        // GET: TipoProveedors/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoProveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoProveedor,nombre,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoProveedor tipoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.TipoProveedor.Add(tipoProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioModifica);
            return View(tipoProveedor);
        }

        // GET: TipoProveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            if (tipoProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioModifica);
            return View(tipoProveedor);
        }

        // POST: TipoProveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoProveedor,nombre,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoProveedor tipoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioModifica);
            return View(tipoProveedor);
        }

        // GET: TipoProveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            if (tipoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoProveedor);
        }

        // POST: TipoProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            db.TipoProveedor.Remove(tipoProveedor);
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
