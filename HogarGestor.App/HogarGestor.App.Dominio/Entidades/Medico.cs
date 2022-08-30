using System.Collections.Generic;

namespace HogarGestor.App.Dominio
{
    public class Medico : Persona
    {
        public string Rethus { get; set; }

        public string TarjetaProfesional { get; set; }

        public Especialidad Especialidad { get; set; }

    }
}
