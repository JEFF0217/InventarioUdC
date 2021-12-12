using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorTipoProductoGUI : MapeadorBaseGUI<tb_tipo_producto, ModeloTipoProductoGUI>
    {
        public override ModeloTipoProductoGUI MapearTipo1Tipo2(tb_tipo_producto entrada)
        {
            return new ModeloTipoProductoGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        public override IEnumerable<ModeloTipoProductoGUI> MapearTipo1Tipo2(IEnumerable<tb_tipo_producto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_tipo_producto MapearTipo2Tipo1(ModeloTipoProductoGUI entrada)
        {
            return new tb_tipo_producto()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };
        }

        public override IEnumerable<tb_tipo_producto> MapearTipo2Tipo1(IEnumerable<ModeloTipoProductoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}