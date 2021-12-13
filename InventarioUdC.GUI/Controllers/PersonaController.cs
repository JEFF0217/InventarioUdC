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
    public class PersonaController : Controller
    {
        private ImplPersonaDatos acceso = new ImplPersonaDatos();

        // GET: Persona
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<tb_persona> listaDatos = acceso.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            IEnumerable<ModeloPersonaGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloPersonaGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.BuscarRegistro(id.Value);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(tb_persona);
            return View(modelo);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Primer_nombre,Otros_nombres,Primer_apellido,Segundo_apellido,Documento,Celular,Correo")] ModeloPersonaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
                tb_persona tb_persona = mapper.MapearTipo2Tipo1(modelo);

                acceso.GuardarRegistro(tb_persona);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.BuscarRegistro(id.Value);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }

            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(tb_persona);
            return View(modelo);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Primer_nombre,Otros_nombres,Primer_apellido,Segundo_apellido,documento,Celular,Correo")] ModeloPersonaGUI modelo)
        {
            if (ModelState.IsValid)
            {

                MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
                tb_persona tb_persona = mapper.MapearTipo2Tipo1(modelo);

                acceso.EditarRegistro(tb_persona);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.BuscarRegistro(id.Value);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(tb_persona);
            return View(modelo);
        }

        // POST: Persona/Delete/5
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
                tb_persona tb_persona = acceso.BuscarRegistro(id);
                if (tb_persona == null)
                {
                    return HttpNotFound();
                }

                MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(tb_persona);
                return View(modelo);
            }
        }

    }
}
