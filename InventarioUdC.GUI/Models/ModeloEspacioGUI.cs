using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloEspacioGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string pisoNombre;

        [DisplayName("Nombre del Piso")]
        public string PisoNombre
        {
            get { return pisoNombre; }
            set { pisoNombre = value; }
        }


        private int id_piso;

        public int Id_piso
        {
            get { return id_piso; }
            set { id_piso = value; }
        }




        private IEnumerable<ModeloPisoGUI> listaPiso;

        public IEnumerable<ModeloPisoGUI> ListaPiso
        {
            get { return listaPiso; }
            set { listaPiso = value; }
        }

    }
}