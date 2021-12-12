﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.Implementacion;

namespace InventarioUdC.GUI.Controllers
{
    public class SedeController : Controller
    {
        private InventarioUdCDBEntities acceso = new InventarioUdCDBEntities();

        // GET: Sede
        public ActionResult Index()
        {
            return View(acceso.tb_sede.ToList());
        }

        // GET: Sede/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = acceso.tb_sede.Find(id);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            return View(tb_sede);
        }

        // GET: Sede/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sede/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,direccion")] tb_sede tb_sede)
        {
            if (ModelState.IsValid)
            {
                acceso.tb_sede.Add(tb_sede);
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_sede);
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = acceso.tb_sede.Find(id);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            return View(tb_sede);
        }

        // POST: Sede/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,direccion")] tb_sede tb_sede)
        {
            if (ModelState.IsValid)
            {
                acceso.Entry(tb_sede).State = EntityState.Modified;
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_sede);
        }

        // GET: Sede/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = acceso.tb_sede.Find(id);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            return View(tb_sede);
        }

        // POST: Sede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_sede tb_sede = acceso.tb_sede.Find(id);
            acceso.tb_sede.Remove(tb_sede);
            acceso.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                acceso.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
