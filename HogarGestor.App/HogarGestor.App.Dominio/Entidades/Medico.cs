namespace HogarGestor.App.Dominio{
    public class Medico : Persona{
        public int Id {get;set;}
        public Especialidad EspecialidadMedica {get;set;}
        public string Rethus {get;set;}
        public string TarjetaProfesional {get;set;}
    }
}