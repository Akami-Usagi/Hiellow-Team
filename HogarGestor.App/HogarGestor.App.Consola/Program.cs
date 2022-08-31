using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Consola
{
    class program
    {

        private static IRepositorioJoven _repoJoven = new RepositorioJoven(new Persistencia.AppContext());
        static void Main(string[] args){
            Console.WriteLine("Hello, World!");
            AddJoven();

        }
        
        private static void AddJoven(){
            var joven = new Joven{
                Nombre = "Camilo",
                Apellidos = "Arango Escobar",
                NumeroTelefono = "3103565058",
                Documento = "1115066671",
                Genero = Generos.Masculino,
                Latitud =  5.07F,
                longitud = -75.687F,
                Ciudad = "Buga",
                FechaNacimiento = new DateTime(1987,06,07)

            };
            _repoJoven.AddJoven(joven);
        }

    }
}