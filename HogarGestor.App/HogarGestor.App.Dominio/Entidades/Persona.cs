using System.Collections.Generic;

namespace HogarGestor.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Documento { get; set; }

        public int TipoDocumentoId { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public int GeneroId { get; set; }

        public Genero Genero { get; set; }
    }
}
