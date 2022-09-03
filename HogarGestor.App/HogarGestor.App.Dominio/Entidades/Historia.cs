using System.Collections.Generic;

namespace HogarGestor.App.Dominio
{
    public class Historia
    {
        public int Id { get; set; }

        public int? Diagnostico { get; set; }

        public string? Entorno { get; set; }

        public List<SugerenciaCuidado> SugerenciaCuidado { get; set; }
    }
}
