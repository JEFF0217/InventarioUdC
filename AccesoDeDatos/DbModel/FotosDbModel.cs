using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel
{
    public class FotosDbModel
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



        private IEnumerable<ProductoDbModel> listaProducto;

        public IEnumerable<ProductoDbModel> ListaProducto
        {
            get { return listaProducto; }
            set { listaProducto = value; }
        }
    }
}
