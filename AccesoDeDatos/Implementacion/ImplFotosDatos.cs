﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;
using AccesoDeDatos.Mapeadores.Parametros;

namespace AccesoDeDatos.Implementacion
{
    public class ImplFotosDatos
    {
        /// <summary>
        /// Metodo para listar registros con filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista con el filtro aplicado</returns>
        public IEnumerable<FotosDbModel> ListarRegistros(string filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<FotosDbModel>();
            using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                var listaDatos = (from m in bd.tb_fotos
                         where m.nombre.Contains(filtro)
                         select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorFotosDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }


        /// <summary>
        /// metodo para almacenar un registro
        /// </summary>
        /// <param name="registro"> el registro a almacenar </param>
        /// <returns>True cuando se almacena y false cuando ya existe el registro igual o una excepcion</returns>
        public bool GuardarRegistro(FotosDbModel registro)
        {
            try
            {
                using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
                {
                    //verificacion de la existencia de un registro con un mismo nombre
                    if (bd.tb_fotos.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }

                    MapeadorFotosDatos mapeador = new MapeadorFotosDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);

                    bd.tb_fotos.Add(reg);
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
        public FotosDbModel BuscarRegistro(int id)
        {
            using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
            {
                tb_fotos registro = bd.tb_fotos.Find(id);
                return new MapeadorFotosDatos().MapearTipo1Tipo2(registro);
            }
        }





        /// <summary>
        /// metodo para editar un registro
        /// </summary>
        /// <param name="registro"> el registro a editar </param>
        /// <returns>True cuando se edita y false cuando no exite el registro igual o una excepcion</returns>
        public bool EditarRegistro(FotosDbModel registro)
        {
            try
            {
                using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
                {
                    //verificacion de la existencia de un registro con un mismo id
                    if (bd.tb_fotos.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }

                    MapeadorFotosDatos mapeador = new MapeadorFotosDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);

                    bd.Entry(reg).State = EntityState.Modified;
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
                    tb_fotos registro = bd.tb_fotos.Find(id);
                    //verificacion de la existencia de un registro con un mismo id
                    if (registro == null)
                    {
                        return false;
                    }

                    bd.tb_fotos.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<FotosDbModel> ListarRegistros()
        {
            var lista = new List<FotosDbModel>();

            using (InventarioUdCDBEntities bd = new InventarioUdCDBEntities())
            {

                //lista = bd.tb_marca.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from m in bd.tb_fotos

                                  select m).ToList();


                lista = new MapeadorFotosDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;

        }
    }
}

