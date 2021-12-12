using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.Implementacion;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using InventarioUdC.GUI.Helpers;

namespace InventarioUdC.GUI.Controllers
{
    public class MarcaController : Controller
    {
        private ImplMarcaDatos acceso = new ImplMarcaDatos();

        // GET: Marca
        public ActionResult Index(string filtro = "")
        {
            IEnumerable<tb_marca> listaDatos = acceso.ListarRegistros(filtro).ToList();
            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            IEnumerable<ModeloMarcaGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            return View(ListaGUI);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = acceso.BuscarRegistro(id.Value);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            ModeloMarcaGUI modelo = mapper.MapearTipo1Tipo2(tb_marca);
            return View(modelo);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloMarcaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
                tb_marca tb_marca = mapper.MapearTipo2Tipo1(modelo);

                acceso.GuardarRegistro(tb_marca);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = acceso.BuscarRegistro(id.Value);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }

            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            ModeloMarcaGUI modelo = mapper.MapearTipo1Tipo2(tb_marca);
            return View(modelo);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloMarcaGUI modelo)
        {
            if (ModelState.IsValid)
            {

                MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
                tb_marca tb_marca = mapper.MapearTipo2Tipo1(modelo);

                acceso.EditarRegistro(tb_marca);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = acceso.BuscarRegistro(id.Value);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            ModeloMarcaGUI modelo = mapper.MapearTipo1Tipo2(tb_marca);
            return View(modelo);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            bool respuesta = acceso.ELiminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                tb_marca tb_marca = acceso.BuscarRegistro(id);
                if (tb_marca == null)
                {
                    return HttpNotFound();
                }

                MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloMarcaGUI modelo = mapper.MapearTipo1Tipo2(tb_marca);
                return View(modelo);
            }
        }

       
    }
}
