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

            //AddFamiliar();
            //AddJoven();
            BuscarJoven(2);
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
                    Parentesco = "Tia",
                    Correo = "diana@gmail.com"
                };
            _repoFamiliar.AddFamiliar (familiar);
        }

        private static void AddJoven()
        {
            var joven =
                new Joven {
                    Nombre = "Dilan Matias",
                    Apellido = "Rojas Lopez",
                    Telefono = "323456891",
                    Documento = "123456789",
                    TipoDocumentoId = 2,
                    GeneroId = 1,
                    Latitud = 5.07F,
                    Longitud = -75.687F,
                    Ciudad = "Cali",
                    FamiliarId = 1,
                    FechaNacimiento = new DateTime(2014, 05, 07)
                };
            _repoJoven.AddJoven (joven);
        }

        private static void BuscarJoven(int IdJoven)
        {
            var joven = _repoJoven.GetJoven(IdJoven);
            Console.WriteLine(joven.Nombre + " " + joven.Apellido);
        }
    }
}
