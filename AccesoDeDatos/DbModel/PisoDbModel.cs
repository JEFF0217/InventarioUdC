using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel
{
    public class PisoDbModel
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
        private int id_edificio;

        public int Id_edificio
        {
            get { return id_edificio; }
            set { id_edificio = value; }
        }


        private IEnumerable<EdificioDbModel> listaEdificio;

        public IEnumerable<EdificioDbModel> ListaEdificio
        {
            get { return listaEdificio; }
            set { listaEdificio = value; }
        }
    }
}
