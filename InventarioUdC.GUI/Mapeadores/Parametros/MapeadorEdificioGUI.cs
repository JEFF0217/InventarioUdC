using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorEdificioGUI : MapeadorBaseGUI<tb_edificio, ModeloEdificioGUI>
    {
        public override ModeloEdificioGUI MapearTipo1Tipo2(tb_edificio entrada)
        {
            return new ModeloEdificioGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Id_Sede = entrada.id_sede
              
            };
        }

        public override IEnumerable<ModeloEdificioGUI> MapearTipo1Tipo2(IEnumerable<tb_edificio> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_edificio MapearTipo2Tipo1(ModeloEdificioGUI entrada)
        {
            return new tb_edificio()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_sede = entrada.Id_Sede
            };
        }

        public override IEnumerable<tb_edificio> MapearTipo2Tipo1(IEnumerable<ModeloEdificioGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}