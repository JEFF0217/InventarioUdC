using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO
{
    public class PisoDTO
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


        private IEnumerable<EdificioDTO> listaEdificio;

        public IEnumerable<EdificioDTO> ListaEdificio
        {
            get { return listaEdificio; }
            set { listaEdificio = value; }
        }

        private string edificioNombre;

        public string EdificioNombre
        {
            get { return edificioNombre; }
            set { edificioNombre = value; }
        }
    }
}
