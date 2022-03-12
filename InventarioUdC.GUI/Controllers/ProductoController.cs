using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using LogicaNegocio.Implementacion;
using InventarioUdC.GUI.Helpers;
using LogicaNegocio.DTO;
using InventarioUdC.GUI.Mapeadores.Parametros;
using InventarioUdC.GUI.Models;
using PagedList;
using System.Collections.Generic;
using System;
using System.IO;

namespace InventarioUdC.GUI.Controllers
{
    public class ProductoController : Controller
    {
        private ImplProductoLogica logica = new ImplProductoLogica();

        // GET: Producto
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;

            IEnumerable<ProductoDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros).ToList();
            IEnumerable<ModeloPersonaGUI> listadoPersonas = obtenerListadoPersonas();
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            IEnumerable<ModeloProductoGUI> ListaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            // var registrosPagina = ListaGUI.ToPagedList(numPagina, registrosPorPagina);
            
            var listaPagina = new StaticPagedList<ModeloProductoGUI>(ListaGUI, numPagina, registrosPorPagina, totalRegistros);
           
            ModeloProductoGUI modelo = new ModeloProductoGUI();
            modelo.ListaPersona = listadoPersonas;
            return View(listaPagina);
        }



        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            IEnumerable<ModeloMarcaGUI> listadoMarcas = obtenerListadoMarcas();
            IEnumerable<ModeloTipoProductoGUI> listaTipoProductos = obtenerListadoTipoProductos();
            IEnumerable<ModeloPersonaGUI> listadoPersonas= obtenerListadoPersonas();
            IEnumerable<ModeloEspacioGUI> listadoEspacio = obtenerListadoEspacios();


            ModeloProductoGUI modelo = new ModeloProductoGUI();
            modelo.ListaMarca = listadoMarcas;
            modelo.ListaTipoProducto = listaTipoProductos;
            modelo.ListaPersona = listadoPersonas;
            modelo.ListaEspacio = listadoEspacio;
            return View(modelo);
        }

        private IEnumerable<ModeloMarcaGUI> obtenerListadoMarcas()
        {
            ImplMarcaLogica sede = new ImplMarcaLogica();
            var listaMarcas = sede.ListarRegistros();
            MapeadorMarcaGUI mapeador = new MapeadorMarcaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMarcas);
            return listado;
        }

        private IEnumerable<ModeloTipoProductoGUI> obtenerListadoTipoProductos()
        {
            ImplTipoProductoLogica sede = new ImplTipoProductoLogica();
            var listaMarcas = sede.ListarRegistros();
            MapeadorTipoProductoGUI mapeador = new MapeadorTipoProductoGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMarcas);
            return listado;
        }
        private IEnumerable<ModeloPersonaGUI> obtenerListadoPersonas()
        {
            ImplPersonaLogica sede = new ImplPersonaLogica();
            var listaMarcas = sede.ListarRegistros();
            MapeadorPersonaGUI mapeador = new MapeadorPersonaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMarcas);
            return listado;
        }
        private IEnumerable<ModeloEspacioGUI> obtenerListadoEspacios()
        {
            ImplEspacioLogica sede = new ImplEspacioLogica();
            var listaEspacios = sede.ListarRegistros();
            MapeadorEspacioGUI mapeador = new MapeadorEspacioGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaEspacios);
            return listado;
        }



        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO ProductoDTO = mapper.MapearTipo2Tipo1(modelo);

                logica.GuardarRegistro(ProductoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }

            IEnumerable<ModeloMarcaGUI> listadoMarcas = obtenerListadoMarcas();
            IEnumerable<ModeloTipoProductoGUI> listaTipoProductos = obtenerListadoTipoProductos();
            IEnumerable<ModeloPersonaGUI> listadoPersonas = obtenerListadoPersonas();
            IEnumerable<ModeloEspacioGUI> listadoEspacio = obtenerListadoEspacios();

            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            modelo.ListaMarca = listadoMarcas;
            modelo.ListaTipoProducto = listaTipoProductos;
            modelo.ListaPersona = listadoPersonas;
            modelo.ListaEspacio = listadoEspacio;
            return View(modelo);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO ProductoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ProductoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // POST: Producto/Delete/5
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
                ProductoDTO ProductoDTO = logica.BuscarRegistro(id);
                if (ProductoDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorAlEliminar;
                ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
                return View(modelo);
            }
        }
      
        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloCargaImagenGUI modelo = CrearModeloCargarImagen(id);

            return View(modelo);
        }
       
       private ModeloCargaImagenGUI CrearModeloCargarImagen(int? id)
       {
           IEnumerable<FotosDTO> listaDto = logica.ListarFotosPorId(id.Value);
           MapeadorFotosGUI mapeador = new MapeadorFotosGUI();
           IEnumerable<ModeloFotosGUI> listaFotos = mapeador.MapearTipo1Tipo2(listaDto);
           if (listaFotos == null)
           {
               listaFotos = new List<ModeloFotosGUI>();
           }
           ModeloCargaImagenGUI modelo = new ModeloCargaImagenGUI()
           {
               Id = id.Value,
               ListadoImagenes = listaFotos
           };
           return modelo;
       }

     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult UploadFile(ModeloCargaImagenGUI modelo)
     {
         try
         {
             if (modelo.Archivo.ContentLength > 0)
             {
                 try
                 {
                     DateTime ahora = DateTime.Now;
                     string fecha_nombre = String.Format("{0}_{1}_{2}_{3}_{4}_{5}", ahora.Day, ahora.Month, ahora.Year, ahora.Hour, ahora.Minute, ahora.Millisecond);
                     string nombreArchivo = String.Concat(fecha_nombre, "_", Path.GetFileName(modelo.Archivo.FileName));
                     string rutaCarpeta = DatosGenerales.RutaArchivos;
                     string rutaCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreArchivo);
                     modelo.Archivo.SaveAs(rutaCompletaArchivo);
                     FotosDTO dto = new FotosDTO()
                     {
                         Id_producto = modelo.Id,
                         Nombre = nombreArchivo

                         
                     };
                     logica.GuardarNombreFoto(dto);
                     // guardar nombre de archivo en base de datos
                     ViewBag.UploadFileMessage = "Archivo cargado correctamente.";

                     ModeloCargaImagenGUI modeloView = CrearModeloCargarImagen(modelo.Id);
                     return View(modeloView);
                 }
                 catch
                 {
                        
                 }
                    
                }
                ViewBag.UploadFileMessage = "Por favor seleccione al menos un archivo a cargar.";
                return View();
            }
         catch (Exception e)
         {
             ViewBag.UploadFileMessage = "Error al cargar el archivo.";
             return View();
         }
     }



     public ActionResult EliminarFoto(int idFoto, string nombreFoto)
     {
         bool respuesta = logica.EliminarRegistroFoto(idFoto);
         if (respuesta)
         {
             string rutaCarpeta = DatosGenerales.RutaArchivos;
             string carpetaEliminados = DatosGenerales.CarpetaFotosEliminadas;
             string rutaOrigenCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreFoto);
             string rutaDestinoCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), carpetaEliminados, nombreFoto);
             System.IO.File.Move(rutaOrigenCompletaArchivo, rutaDestinoCompletaArchivo);
         }
         return RedirectToAction("Index");
     }
    }
}
