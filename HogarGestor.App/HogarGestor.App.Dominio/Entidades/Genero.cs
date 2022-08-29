using System.Collections.Generic;

namespace HogarGestor.App.Dominio
{
    public class Genero
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Abreviatura { get; set; }

        public List<Persona> Persona { get; set; }
    }
}
