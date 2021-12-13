using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using InventarioUdC.GUI.Helpers;
using PagedList;
using LogicaNegocio.DTO;
using LogicaNegocio.Implementacion;

namespace InventarioUdC.GUI.Controllers
{
    public class PersonaController : Controller
    {
        private ImplPersonaLogica logica = new ImplPersonaLogica();

        // GET: Persona
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<PersonaDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
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
            PersonaDTO PersonaDTO = logica.BuscarRegistro(id.Value);
            if (PersonaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(PersonaDTO);
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
                PersonaDTO PersonaDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.GuardarRegistro(PersonaDTO);
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
            PersonaDTO PersonaDTO = logica.BuscarRegistro(id.Value);
            if (PersonaDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(PersonaDTO);
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
                PersonaDTO PersonaDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.EditarRegistro(PersonaDTO);
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
            PersonaDTO PersonaDTO = logica.BuscarRegistro(id.Value);
            if (PersonaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(PersonaDTO);
            return View(modelo);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                PersonaDTO PersonaDTO = logica.BuscarRegistro(id);
                if (PersonaDTO == null)
                {
                    return HttpNotFound();
                }

                MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloPersonaGUI modelo = mapper.MapearTipo1Tipo2(PersonaDTO);
                return View(modelo);
            }
        }

    }
}
