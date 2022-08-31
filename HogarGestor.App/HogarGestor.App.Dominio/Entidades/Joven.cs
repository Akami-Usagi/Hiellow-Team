using System.Collections.Generic;

namespace HogarGestor.App.Dominio
{
    public class Joven : Persona
    {
        public string? Direccion { get; set; }

        public float? Latitud { get; set; }

        public float? Longitud { get; set; }

        public string? Ciudad { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public int? FamiliarId { get; set; }

        public Familiar? Familiar { get; set; }

        public int? PediatraId { get; set; }

        public Medico? Pediatra { get; set; }

        public int? NutricionistaId { get; set; }

        public Medico? Nutricionista { get; set; }

        public List<Historia> HistoriaJoven { get; set; }

        public List<PatronesCrecimiento> PatronesCrecimientoJoven { get; set; }
    }
}
