using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;
using AccesoDeDatos.DbModel;
namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorPersonaDatos : MapeadorBaseDatos<tb_persona, PersonaDbModel>
    {
        public override PersonaDbModel MapearTipo1Tipo2(tb_persona entrada)
        {
            return new PersonaDbModel()
            {
                Id = entrada.id,
                Primer_nombre = entrada.primer_nombre,
                Otros_nombres = entrada.otros_nombres,
                Primer_apellido = entrada.segundo_apellido,
                Segundo_apellido = entrada.segundo_apellido,
                Celular = entrada.celular,
                Correo = entrada.correo,
                Documento = entrada.documento

            };
        }

        public override IEnumerable<PersonaDbModel> MapearTipo1Tipo2(IEnumerable<tb_persona> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_persona MapearTipo2Tipo1(PersonaDbModel entrada)
        {
            return new tb_persona()
            {
                id = entrada.Id,
                primer_nombre = entrada.Primer_nombre,
                otros_nombres = entrada.Otros_nombres,
                primer_apellido = entrada.Segundo_apellido,
                segundo_apellido = entrada.Segundo_apellido,
                celular = entrada.Celular,
                correo = entrada.Correo,
                documento = entrada.Documento
            };
        }

        public override IEnumerable<tb_persona> MapearTipo2Tipo1(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}