﻿
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using AccesoDeDatos.ModeloDeDatos;

namespace AccesoDeDatos.Implementacion
{
    public class ImplTipoProductoDatos
    {
        /// <summary>
        /// Metodo para listar registros con filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista con el filtro aplicado</returns>
        public IEnumerable<tb_tipo_producto> ListarRegistros(string filtro)
        {
            var lista = new List<tb_tipo_producto>();
            using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
            {
                if (String.IsNullOrWhiteSpace(filtro))
                {
                    lista = bd.tb_tipo_producto.ToList();
                }
                else
                {
                    lista = bd.tb_tipo_producto.Where(x => x.nombre.ToUpper().Contains(filtro.ToUpper())).ToList();
                }

            }
            return lista;
        }


        /// <summary>
        /// metodo para almacenar un registro
        /// </summary>
        /// <param name="registro"> el registro a almacenar </param>
        /// <returns>True cuando se almacena y false cuando ya existe el registro igual o una excepcion</returns>
        public bool GuardarRegistro(tb_tipo_producto registro)
        {
            try
            {
                using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
                {
                    //verificacion de la existencia de un registro con un mismo nombre
                    if (bd.tb_tipo_producto.Where(x => x.nombre.ToLower().Equals(registro.nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }

                    bd.tb_tipo_producto.Add(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// metodo para realizar la busqueda de un registro
        /// </summary>
        /// <param name="id"> El id del registro a buscar</param>
        /// <returns>retorna el objeto con el id buscado o null cuando no existe    </returns>
        public tb_tipo_producto BuscarRegistro(int id)
        {
            using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
            {
                tb_tipo_producto registro = bd.tb_tipo_producto.Find(id);
                return registro;
            }
        }





        /// <summary>
        /// metodo para editar un registro
        /// </summary>
        /// <param name="registro"> el registro a editar </param>
        /// <returns>True cuando se edita y false cuando no exite el registro igual o una excepcion</returns>
        public bool EditarRegistro(tb_tipo_producto registro)
        {
            try
            {
                using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
                {
                    //verificacion de la existencia de un registro con un mismo id
                    if (bd.tb_tipo_producto.Where(x => x.id == registro.id).Count() == 0)
                    {
                        return false;
                    }

                    bd.Entry(registro).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// metodo para eliminar un registro
        /// </summary>
        /// <param name="id"> identificador del registro a eliminar </param>
        /// <returns>True cuando se elimina y false cuando no exite el registro  o una excepcion</returns>
        public bool ELiminarRegistro(int id)
        {
            try
            {
                using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
                {
                    tb_tipo_producto registro = bd.tb_tipo_producto.Find(id);
                    //verificacion de la existencia de un registro con un mismo id
                    if (registro == null || registro.tb_producto.Count() > 0)
                    {
                        return false;
                    }

                    bd.tb_tipo_producto.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}