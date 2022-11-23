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
    public class VehiculoesController : Controller
    {
        private CafeteriaEntities db = new CafeteriaEntities();

        // GET: Vehiculoes
        public ActionResult Index()
        {
            var vehiculo = db.Vehiculo.Include(v => v.Trabajador).Include(v => v.Usuario).Include(v => v.Usuario1);
            return View(vehiculo.ToList());
        }

        // GET: Vehiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculoes/Create
        public ActionResult Create()
        {
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Vehiculoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVehiculo,numero,descripcion,idTrabajador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", vehiculo.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", vehiculo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", vehiculo.idUsuarioModifica);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", vehiculo.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", vehiculo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", vehiculo.idUsuarioModifica);
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVehiculo,numero,descripcion,idTrabajador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTrabajador = new SelectList(db.Trabajador, "idTrabajador", "nombre", vehiculo.idTrabajador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", vehiculo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", vehiculo.idUsuarioModifica);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            db.Vehiculo.Remove(vehiculo);
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
