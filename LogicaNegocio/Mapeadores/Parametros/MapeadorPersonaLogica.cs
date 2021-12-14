using AccesoDeDatos.DbModel;
using System.Collections.Generic;
using LogicaNegocio.DTO;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorPersonaLogica : MapeadorBaseLogica<PersonaDbModel, PersonaDTO>
    {
        public override PersonaDTO MapearTipo1Tipo2(PersonaDbModel entrada)
        {
            return new PersonaDTO()
            {
                Id = entrada.Id,
                Primer_nombre = entrada.Primer_nombre,
                Otros_nombres = entrada.Otros_nombres,
                Primer_apellido = entrada.Segundo_apellido,
                Segundo_apellido = entrada.Segundo_apellido,
                Celular = entrada.Celular,
                Correo = entrada.Correo,
                Documento = entrada.Documento

            };
        }

        public override IEnumerable<PersonaDTO> MapearTipo1Tipo2(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDbModel MapearTipo2Tipo1(PersonaDTO entrada)
        {
            return new PersonaDbModel()
            {
                Id = entrada.Id,
                Primer_nombre = entrada.Primer_nombre,
                Otros_nombres = entrada.Otros_nombres,
                Primer_apellido = entrada.Segundo_apellido,
                Segundo_apellido = entrada.Segundo_apellido,
                Celular = entrada.Celular,
                Correo = entrada.Correo,
                Documento = entrada.Documento
            };
        }

        public override IEnumerable<PersonaDbModel> MapearTipo2Tipo1(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}