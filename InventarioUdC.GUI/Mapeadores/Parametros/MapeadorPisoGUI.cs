using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorPisoGUI : MapeadorBaseGUI<tb_piso, ModeloPisoGUI>
    {
        public override ModeloPisoGUI MapearTipo1Tipo2(tb_piso entrada)
        {
            return new ModeloPisoGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Id_edificio = entrada.id_edificio
            };
        }

        public override IEnumerable<ModeloPisoGUI> MapearTipo1Tipo2(IEnumerable<tb_piso> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_piso MapearTipo2Tipo1(ModeloPisoGUI entrada)
        {
            return new tb_piso()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_edificio = entrada.Id_edificio
            };
        }

        public override IEnumerable<tb_piso> MapearTipo2Tipo1(IEnumerable<ModeloPisoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}