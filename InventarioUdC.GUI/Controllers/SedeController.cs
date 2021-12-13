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
using PagedList;

namespace InventarioUdC.GUI.Controllers
{
    public class SedeController : Controller
    {
        private ImplSedeDatos acceso = new ImplSedeDatos();

        // GET: Sede
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<tb_sede> listaDatos = acceso.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            IEnumerable<ModeloSedeGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloSedeGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Sede/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = acceso.BuscarRegistro(id.Value);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(tb_sede);
            return View(modelo);
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
        public ActionResult Create([Bind(Include = "Id,Nombre,Direccion")] ModeloSedeGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                tb_sede tb_sede = mapper.MapearTipo2Tipo1(modelo);

                acceso.GuardarRegistro(tb_sede);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = acceso.BuscarRegistro(id.Value);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }

            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(tb_sede);
            return View(modelo);
        }

        // POST: Sede/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion")] ModeloSedeGUI modelo)
        {
            if (ModelState.IsValid)
            {

                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                tb_sede tb_sede = mapper.MapearTipo2Tipo1(modelo);

                acceso.EditarRegistro(tb_sede);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Sede/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = acceso.BuscarRegistro(id.Value);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(tb_sede);
            return View(modelo);
        }

        // POST: Sede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acceso.ELiminarRegistro(id);
            return RedirectToAction("Index");
            bool respuesta = acceso.ELiminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                tb_sede tb_sede = acceso.BuscarRegistro(id);
                if (tb_sede == null)
                {
                    return HttpNotFound();
                }

                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(tb_sede);
                return View(modelo);
            }
        }

    }
}
