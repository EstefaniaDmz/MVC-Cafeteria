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
    public class MaterialsController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Materials
        public ActionResult Index()
        {
            var material = db.Material.Include(m => m.Almacen).Include(m => m.Compra).Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(material.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            ViewBag.idAlmacen = new SelectList(db.Almacen, "idAlmacen", "numero");
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Materials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMaterial,nombre,descripcion,precio,cantidad,idCompra,idAlmacen,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Material.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAlmacen = new SelectList(db.Almacen, "idAlmacen", "numero", material.idAlmacen);
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia", material.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", material.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", material.idUsuarioModifica);
            return View(material);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAlmacen = new SelectList(db.Almacen, "idAlmacen", "numero", material.idAlmacen);
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia", material.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", material.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", material.idUsuarioModifica);
            return View(material);
        }

        // POST: Materials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMaterial,nombre,descripcion,precio,cantidad,idCompra,idAlmacen,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAlmacen = new SelectList(db.Almacen, "idAlmacen", "numero", material.idAlmacen);
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "referencia", material.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", material.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", material.idUsuarioModifica);
            return View(material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Material.Find(id);
            db.Material.Remove(material);
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
