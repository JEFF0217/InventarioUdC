using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorFotosGUI : MapeadorBaseGUI<tb_fotos, ModeloFotosGUI>
    {
        public override ModeloFotosGUI MapearTipo1Tipo2(tb_fotos entrada)
        {
            return new ModeloFotosGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Id_producto = entrada.id_producto
            };
        }

        public override IEnumerable<ModeloFotosGUI> MapearTipo1Tipo2(IEnumerable<tb_fotos> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_fotos MapearTipo2Tipo1(ModeloFotosGUI entrada)
        {
            return new tb_fotos()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_producto = entrada.Id_producto
            };
        }

        public override IEnumerable<tb_fotos> MapearTipo2Tipo1(IEnumerable<ModeloFotosGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}