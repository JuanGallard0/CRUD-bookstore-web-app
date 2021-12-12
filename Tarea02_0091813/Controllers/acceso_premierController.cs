using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea02_0091813.Models;

namespace Tarea02_0091813.Controllers
{
    public class acceso_premierController : Controller
    {
        private tarea2Entities db = new tarea2Entities();

        // GET: acceso_premier
        public ActionResult Index()
        {
            var acceso_premier = db.acceso_premier.Include(a => a.persona).Include(a => a.pelicula);
            return View(acceso_premier.ToList());
        }

        // GET: acceso_premier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            if (acceso_premier == null)
            {
                return HttpNotFound();
            }
            return View(acceso_premier);
        }

        // GET: acceso_premier/Create
        public ActionResult Create()
        {
            ViewBag.idpersona = new SelectList(db.personas, "idpersona", "nombre");
            ViewBag.nombre_pelicula = new SelectList(db.peliculas, "nombre", "nombre");
            return View();
        }

        // POST: acceso_premier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idapremier,nombre_pelicula,idpersona")] acceso_premier acceso_premier)
        {
            if (ModelState.IsValid)
            {
                db.acceso_premier.Add(acceso_premier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idpersona = new SelectList(db.personas, "idpersona", "nombre", acceso_premier.idpersona);
            ViewBag.nombre_pelicula = new SelectList(db.peliculas, "nombre", "clasificacion", acceso_premier.nombre_pelicula);
            return View(acceso_premier);
        }

        // GET: acceso_premier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            if (acceso_premier == null)
            {
                return HttpNotFound();
            }
            ViewBag.idpersona = new SelectList(db.personas, "idpersona", "nombre", acceso_premier.idpersona);
            ViewBag.nombre_pelicula = new SelectList(db.peliculas, "nombre", "clasificacion", acceso_premier.nombre_pelicula);
            return View(acceso_premier);
        }

        // POST: acceso_premier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idapremier,nombre_pelicula,idpersona")] acceso_premier acceso_premier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acceso_premier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idpersona = new SelectList(db.personas, "idpersona", "nombre", acceso_premier.idpersona);
            ViewBag.nombre_pelicula = new SelectList(db.peliculas, "nombre", "clasificacion", acceso_premier.nombre_pelicula);
            return View(acceso_premier);
        }

        // GET: acceso_premier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            if (acceso_premier == null)
            {
                return HttpNotFound();
            }
            return View(acceso_premier);
        }

        // POST: acceso_premier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            db.acceso_premier.Remove(acceso_premier);
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
