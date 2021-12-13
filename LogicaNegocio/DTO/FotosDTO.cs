using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO
{
    public class FotosDTO
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
        private int id_producto;

        public int Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }



        private IEnumerable<ProductoDTO> listaProducto;

        public IEnumerable<ProductoDTO> ListaProducto
        {
            get { return listaProducto; }
            set { listaProducto = value; }
        }
    }
}
