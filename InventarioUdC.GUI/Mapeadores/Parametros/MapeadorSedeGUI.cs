using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccesoDeDatos.ModeloDeDatos;
using InventarioUdC.GUI.Models;

namespace InventarioUdC.GUI.Mapeadores.Parametros
{
    public class MapeadorSedeGUI : MapeadorBaseGUI<tb_sede, ModeloSedeGUI>
    {
        public override ModeloSedeGUI MapearTipo1Tipo2(tb_sede entrada)
        {
            return new ModeloSedeGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Direccion = entrada.direccion
            };
        }

        public override IEnumerable<ModeloSedeGUI> MapearTipo1Tipo2(IEnumerable<tb_sede> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_sede MapearTipo2Tipo1(ModeloSedeGUI entrada)
        {
            return new tb_sede()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                direccion = entrada.Direccion
            };
        }

        public override IEnumerable<tb_sede> MapearTipo2Tipo1(IEnumerable<ModeloSedeGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}