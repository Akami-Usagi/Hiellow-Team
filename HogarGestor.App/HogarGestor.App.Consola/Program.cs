// See https://aka.ms/new-console-template for more information
using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Consola
{
    public class Program
    {
        private static IRepositorioFamiliar
            _repoFamiliar =
                new RepositorioFamiliar(new Persistencia.AppContext());

        private static IRepositorioJoven
            _repoJoven = new RepositorioJoven(new Persistencia.AppContext());

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //var joven = _repoJoven.GetJoven(3);
            //Console.WriteLine(joven.Nombre + " " + joven.Apellido);
           
            //AddFamiliar();
            //AddJoven();
            //BuscarJoven(2);

            DeleteJoven(4);
        }

        private static void AddFamiliar()
        {
            var familiar =
                new Familiar {
                    Nombre = "Diana Julieth",
                    Apellido = "Rojas",
                    Telefono = "4012044",
                    Documento = "11456789",
                    TipoDocumentoId = 1,
                    GeneroId = 2,
                    Parentesco = "Mama",
                    Correo = "diana@gmail.com"
                };
            _repoFamiliar.AddFamiliar (familiar);
        }

        private static void AddJoven()
        {
            var joven =
                new Joven {
                    Nombre = "Sandra",
                    Apellido = "Vargas",
                    Telefono = "323456891",
                    Documento = "123456789",
                    TipoDocumentoId = 2,
                    GeneroId = 1,
                    Latitud = 5.07F,
                    Longitud = -75.687F,
                    Ciudad = "Cali",
                    FechaNacimiento = new DateTime(2014, 05, 07)
                };
            _repoJoven.AddJoven (joven);
        }

        public static void UpdateJoven(Joven joven)
        {
            
        }

        private static void DeleteJoven(int idJoven)
        {

            _repoJoven.DeleteJoven(idJoven);

        }

        
    }
}
