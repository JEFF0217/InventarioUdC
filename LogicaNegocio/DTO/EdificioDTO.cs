using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO
{
    public class EdificioDTO
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

        public string SedeNombre
        {
            get { return sedeNombre; }
            set { sedeNombre = value; }
        }

        private IEnumerable<SedeDTO> listaSede;

        public IEnumerable<SedeDTO> ListaSede
        {
            get { return listaSede; }
            set { listaSede = value; }
        }
    }
}
