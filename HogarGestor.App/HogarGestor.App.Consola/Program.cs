
using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Consola
{
    class Program
    {

        private static IRepositorioJoven _repoJoven = new RepositorioJoven(new Persistencia.AppContext());
        static void Main(string[] args){
            Console.WriteLine("Hello, World!");
            AddJoven();
            //BuscarJoven("1115066671");

        }
        
        private static void AddJoven(){
            Console.WriteLine("Ingrese Su Nombre: ");
            string? NombreJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Sus Apellidos: ");
            string? ApellidosJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Su Numero De Telefono: ");
            string? TelefonoJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Su Numero De Documento: ");
            string? DocumentoJoven = Console.ReadLine();
            Console.WriteLine("Digite el Numero Su Genero: 1-Masculino  2-Femenino  3-Intersexual");
            string? SelectGenero = Console.ReadLine();

            Generos? generoEscojido = null;
            if(SelectGenero == "1"){
                generoEscojido = Generos.Masculino;
            }
            else if (SelectGenero == "2"){
                generoEscojido = Generos.Femenino;
            }
            else if (SelectGenero == "3"){
                generoEscojido = Generos.Intersexual;
            }
            Console.WriteLine("Ingrese El Nombre De Su Ciudad: ");
            string? CiudadJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Su Año De Nacimiento: ");
            int Año = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese Su Mes De Nacimiento: ");
            int Mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese Su Dia De Nacimiento: ");
            int Dia = Convert.ToInt32(Console.ReadLine());

            var joven = new Joven{
                Nombre = NombreJoven,
                Apellidos = ApellidosJoven,
                NumeroTelefono = TelefonoJoven,
                Documento = DocumentoJoven,
                Genero = generoEscojido,
                Latitud =  5.07F,
                Longitud = -75.687F,
                Ciudad = CiudadJoven,
                FechaNacimiento = new DateTime(Año,Mes,Dia)

            };
            _repoJoven.AddJoven(joven);
        }

        private static void BuscarJoven(string DocumentoJoven){
            var joven = _repoJoven.GetJoven(DocumentoJoven);
            Console.WriteLine(joven.Nombre + " " + joven.Apellidos);
        }

    }
}