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
    public class PlatilloMaterialsController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: PlatilloMaterials
        public ActionResult Index()
        {
            var platilloMaterial = db.PlatilloMaterial.Include(p => p.Material).Include(p => p.Platillo).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(platilloMaterial.ToList());
        }

        // GET: PlatilloMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatilloMaterial platilloMaterial = db.PlatilloMaterial.Find(id);
            if (platilloMaterial == null)
            {
                return HttpNotFound();
            }
            return View(platilloMaterial);
        }

        // GET: PlatilloMaterials/Create
        public ActionResult Create()
        {
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "nombre");
            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: PlatilloMaterials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlatilloMaterial,idPlatillo,idMaterial,cantidad,unidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PlatilloMaterial platilloMaterial)
        {
            if (ModelState.IsValid)
            {
                db.PlatilloMaterial.Add(platilloMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "nombre", platilloMaterial.idMaterial);
            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre", platilloMaterial.idPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platilloMaterial.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platilloMaterial.idUsuarioModifica);
            return View(platilloMaterial);
        }

        // GET: PlatilloMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatilloMaterial platilloMaterial = db.PlatilloMaterial.Find(id);
            if (platilloMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "nombre", platilloMaterial.idMaterial);
            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre", platilloMaterial.idPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platilloMaterial.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platilloMaterial.idUsuarioModifica);
            return View(platilloMaterial);
        }

        // POST: PlatilloMaterials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlatilloMaterial,idPlatillo,idMaterial,cantidad,unidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PlatilloMaterial platilloMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platilloMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "nombre", platilloMaterial.idMaterial);
            ViewBag.idPlatillo = new SelectList(db.Platillo, "idPlatillo", "nombre", platilloMaterial.idPlatillo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", platilloMaterial.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", platilloMaterial.idUsuarioModifica);
            return View(platilloMaterial);
        }

        // GET: PlatilloMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlatilloMaterial platilloMaterial = db.PlatilloMaterial.Find(id);
            if (platilloMaterial == null)
            {
                return HttpNotFound();
            }
            return View(platilloMaterial);
        }

        // POST: PlatilloMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatilloMaterial platilloMaterial = db.PlatilloMaterial.Find(id);
            db.PlatilloMaterial.Remove(platilloMaterial);
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
