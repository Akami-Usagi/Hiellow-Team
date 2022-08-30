using System.Collections.Generic;

namespace HogarGestor.App.Dominio
{
    public class Joven : Persona
    {
        public string Direccion { get; set; }

        public float Latitud { get; set; }

        public float longitud { get; set; }

        public string Ciudad { get; set; }

        public Familiar Familiar { get; set; }

        public Medico Pediatra { get; set; }

        public Medico Nutricionista { get; set; }

        public List<Historia> HistoriaJoven { get; set; }

        public List<PatronesCrecimiento> PatronesCrecimiento { get; set; }
    }
}
