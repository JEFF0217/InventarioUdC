using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Models
{
    public class ModeloEdificioGUI
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
        private int id_sede;

        public int Id_Sede
        {
            get { return id_sede; }
            set { id_sede = value; }
        }


        private string sedeNombre;
        [DisplayName("Nombre de la sede")]
        public string SedeNombre
        {
            get { return sedeNombre; }
            set { sedeNombre = value; }
        }



        private IEnumerable<ModeloSedeGUI> listaSede;

        public IEnumerable<ModeloSedeGUI> ListaSede
        {
            get { return listaSede; }
            set { listaSede = value; }
        }

    }
}