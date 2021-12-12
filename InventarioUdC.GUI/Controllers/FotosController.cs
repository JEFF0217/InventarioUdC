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
    public class FotosController : Controller
    {
        private InventarioUdCDBEntities acceso = new InventarioUdCDBEntities();

        // GET: Fotos
        public ActionResult Index()
        {
            var tb_fotos = acceso.tb_fotos.Include(t => t.tb_producto);
            return View(tb_fotos.ToList());
        }

        // GET: Fotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_fotos tb_fotos = acceso.tb_fotos.Find(id);
            if (tb_fotos == null)
            {
                return HttpNotFound();
            }
            return View(tb_fotos);
        }

        // GET: Fotos/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(acceso.tb_producto, "id", "nombre");
            return View();
        }

        // POST: Fotos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,id_producto")] tb_fotos tb_fotos)
        {
            if (ModelState.IsValid)
            {
                acceso.tb_fotos.Add(tb_fotos);
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(acceso.tb_producto, "id", "nombre", tb_fotos.id_producto);
            return View(tb_fotos);
        }

        // GET: Fotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_fotos tb_fotos = acceso.tb_fotos.Find(id);
            if (tb_fotos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(acceso.tb_producto, "id", "nombre", tb_fotos.id_producto);
            return View(tb_fotos);
        }

        // POST: Fotos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,id_producto")] tb_fotos tb_fotos)
        {
            if (ModelState.IsValid)
            {
                acceso.Entry(tb_fotos).State = EntityState.Modified;
                acceso.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(acceso.tb_producto, "id", "nombre", tb_fotos.id_producto);
            return View(tb_fotos);
        }

        // GET: Fotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_fotos tb_fotos = acceso.tb_fotos.Find(id);
            if (tb_fotos == null)
            {
                return HttpNotFound();
            }
            return View(tb_fotos);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_fotos tb_fotos = acceso.tb_fotos.Find(id);
            acceso.tb_fotos.Remove(tb_fotos);
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
