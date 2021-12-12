using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorCategoriaGUI : MapeadorBaseGUI<tb_categoria, ModeloCategoriaGUI>
    {
        public override ModeloCategoriaGUI MapearTipo1Tipo2(tb_categoria entrada)
        {
            return new ModeloCategoriaGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        public override IEnumerable<ModeloCategoriaGUI> MapearTipo1Tipo2(IEnumerable<tb_categoria> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_categoria MapearTipo2Tipo1(ModeloCategoriaGUI entrada)
        {
            return new tb_categoria()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };
        }

        public override IEnumerable<tb_categoria> MapearTipo2Tipo1(IEnumerable<ModeloCategoriaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}