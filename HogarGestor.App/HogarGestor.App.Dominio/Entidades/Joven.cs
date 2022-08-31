namespace HogarGestor.App.Dominio{
    public class Joven : Persona{
        
        public string Direccion {get;set;}
        public float Latitud {get;set;}
        public float longitud {get;set;}
        public string Ciudad {get;set;}
        public DateTime FechaNacimiento {get;set;}
        public Familiar FamiliarDesignado {get;set;}
        public Medico Pediatra {get;set;}
        public Medico Nutricionista {get;set;}
        public Historia HistoriaJoven {get;set;}
        
    }
}