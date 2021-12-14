using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace InventarioUdC.GUI.Helpers
{
    public static class DatosGenerales
    {
        public static int RegistrosPorPagina = Int32.Parse(ConfigurationManager.AppSettings["registrosPorPagina"].ToString());
        public static String RutaArchivos = ConfigurationManager.AppSettings["rutaArchivos"].ToString();
        public static String CarpetaFotosEliminadas = ConfigurationManager.AppSettings["carpetaFotosEliminadas"].ToString();
        public static String RutaMostrarArchivos = ConfigurationManager.AppSettings["rutaMostrarArchivos"].ToString();
    }
}