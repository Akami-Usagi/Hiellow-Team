using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogarGestor.App.Dominio.Entidades
{
    public class Joven
    {
        public int Id {get;set;}
        public string Direccion {get;set;}
        public float Latitud {get;set;}
        public float longitud {get;set;}
        public string Ciudad {get;set;}
        public DateTime FechaNacimiento {get;set;}
        public Familiar FamiliarDesignado {get;set;}
        public Medico MedicoAsignado {get;set;}
        public Historia HistoriaJoven {get;set;}
        
    }
}