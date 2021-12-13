using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorEspacioGUI : MapeadorBaseGUI<tb_espacio, ModeloEspacioGUI>
    {
        public override ModeloEspacioGUI MapearTipo1Tipo2(tb_espacio entrada)
        {
            return new ModeloEspacioGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Id_piso = entrada.id_piso
                
            };
        }

        public override IEnumerable<ModeloEspacioGUI> MapearTipo1Tipo2(IEnumerable<tb_espacio> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_espacio MapearTipo2Tipo1(ModeloEspacioGUI entrada)
        {
            return new tb_espacio()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_piso = entrada.Id_piso
          
            };
        }

        public override IEnumerable<tb_espacio> MapearTipo2Tipo1(IEnumerable<ModeloEspacioGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}