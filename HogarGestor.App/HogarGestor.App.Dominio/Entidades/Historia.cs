using System.Collections.Generic;
namespace HogarGestor.App.Dominio{
    public class Historia{
        public int Id {get;set;}
        public string Registro {get;set;}
        public List<SugerenciaCuidado> SugerenciasCuidado {get;set;}
        public List<PatronesCrecimiento> PatronCrecimiento {get;set;}
    }
}