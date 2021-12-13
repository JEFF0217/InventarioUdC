using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;


namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorProductoGUI : MapeadorBaseGUI<tb_producto, ModeloProductoGUI>
    {
        public override ModeloProductoGUI MapearTipo1Tipo2(tb_producto entrada)
        {
            return new ModeloProductoGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Fecha_registro = (DateTime)entrada.fecha_registro,
                Serial = entrada.serieal,
                Id_tipo_producto = entrada.id_tipo_producto,
                Id_espacio = entrada.id_espacio,
                Id_marca = entrada.id_marca,
                Id_persona = entrada.id_persona
               
            };
        }

        public override IEnumerable<ModeloProductoGUI> MapearTipo1Tipo2(IEnumerable<tb_producto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_producto MapearTipo2Tipo1(ModeloProductoGUI entrada)
        {
            return new tb_producto()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                fecha_registro = entrada.Fecha_registro,
                serieal = entrada.Serial,
                id_tipo_producto = entrada.Id_tipo_producto,
                id_espacio = entrada.Id_espacio,
                id_marca = entrada.Id_marca,
                id_persona = entrada.Id_persona

            };
        }

        public override IEnumerable<tb_producto> MapearTipo2Tipo1(IEnumerable<ModeloProductoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}