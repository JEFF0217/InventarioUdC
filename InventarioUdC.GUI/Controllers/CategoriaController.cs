using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventarioUdC.GUI.Helpers;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using LogicaNegocio.DTO;
using LogicaNegocio.Implementacion;
using PagedList;


namespace InventarioUdC.GUI.Controllers
{
    public class CategoriaController : Controller
    {
        private ImplCategoriaLogica logica = new ImplCategoriaLogica();

        // GET: Categoria
        public ActionResult Index(int? page, string filtro = "")
        {

            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<CategoriaDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            IEnumerable<ModeloCategoriaGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloCategoriaGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = logica.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO CategoriaDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.GuardarRegistro(CategoriaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = logica.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO CategoriaDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.EditarRegistro(CategoriaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        } 

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = logica.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else {
                CategoriaDTO CategoriaDTO = logica.BuscarRegistro(id);
                if (CategoriaDTO == null)
                {
                    return HttpNotFound();
                }

                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;

                ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
                return View(modelo);
            }

            
        }
    }
}
