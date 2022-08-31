// See https://aka.ms/new-console-template for more information
using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Consola
{
    public class Program
    {
        //private static IRepositorioFamiliar _repoFamiliar = new RepositorioFamiliar(new Persistencia.AppContext());

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //AddFamiliar();
        }

        /*private static void AddFamiliar()
        {
            var familiar =
                new Familiar {
                    Nombre = "Diana Julieth",
                    Apellido = "Rojas",
                    Telefono = "4012044",
                    Documento = "11456789",
                    TipoDocumentoId=1,
                    GeneroId = 2,
                    Parentesco="Tia",
                    Correo="diana@gmail.com"
                };
            _repoFamiliar.AddFamiliar(familiar);
        }*/
    }
}
