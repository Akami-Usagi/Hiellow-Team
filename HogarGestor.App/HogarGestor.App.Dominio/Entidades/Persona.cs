namespace HogarGestor.App.Dominio{
    public class Persona{
        public int Id {get;set;}
        public string? Nombre {get;set;}
        public string? Apellidos {get;set;}
        public string? Documento {get;set;}
        public string? NumeroTelefono {get;set;}
        public Generos? Genero {get;set;}
        public TipoDocumento? DocumentoTipo {get;set;}
    }
}