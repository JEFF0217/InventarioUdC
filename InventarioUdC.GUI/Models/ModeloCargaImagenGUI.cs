using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InventarioUdC.GUI.Helpers;

namespace InventarioUdC.GUI.Models
{
    public class ModeloCargaImagenGUI
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private HttpPostedFileBase archivo;

        [Required]
        public HttpPostedFileBase Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        private IEnumerable<ModeloFotosGUI> listadoImagenes;

        public IEnumerable<ModeloFotosGUI> ListadoImagenes
        {
            get { return listadoImagenes; }
            set { listadoImagenes = value; }
        }

        private String rutaImagen = DatosGenerales.RutaMostrarArchivos;

        public String RutaImagen
        {
            get { return rutaImagen; }
        }

    }
}