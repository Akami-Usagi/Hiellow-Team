
using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;

namespace HogarGestor.App.Consola
{
    class Program
    {

        private static IRepositorioJoven _repoJoven = new RepositorioJoven(new Persistencia.AppContext());
        static void Main(string[] args){
            Console.WriteLine("Bienvenido a HogarGestor.App Ingresa el Numero de la opcion que deseas realizar:");
            Console.WriteLine("Ingrese 1 para agregar un joven.  - Ingrese 2 Para Buscar en la base de datos");
            Console.WriteLine("Ingrese 3 para eliminar un joven.  - Ingrese 4 Editar un Joven");
            string Option = Console.ReadLine();
            if (Option == "1"){
                AddJoven();
            }
            else if (Option == "2"){
                BuscarJoven();
            }
             else if (Option == "3"){
                EliminarJoven();
            }
             else if (Option == "4"){
                ActualizarJoven();
            }
            

        }
        
        private static void AddJoven(){
            Console.WriteLine("Se Va Agregar Un Nuevo Joven Al Sistema: ");
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
            Console.WriteLine("Datos Del Joven Agregados Satisfactoriamente!");
        }

        private static void BuscarJoven(){
            Console.WriteLine("Ingrese El Numero De Documento a Buscar: ");
            string? DocumentoJoven = Console.ReadLine();
            var joven = _repoJoven.GetJoven(DocumentoJoven);
            Console.WriteLine("Datos Del Joven Encontrados! ");
            Console.WriteLine("Nombre Completo: " + joven.Nombre + " " + joven.Apellidos);
            Console.WriteLine("Documento: " + joven.Documento);
            Console.WriteLine("Numero de Telefono: " + joven.NumeroTelefono);
        }

        private static void EliminarJoven(){
            Console.WriteLine("Ingrese El Numero De Documento del Joven a Eliminar: ");
            string? DocumentoJoven = Console.ReadLine();
            var joven = _repoJoven.GetJoven(DocumentoJoven);
            Console.WriteLine("Datos Del Joven Encontrados! ");
            Console.WriteLine("Nombre Completo: " + joven.Nombre + " " + joven.Apellidos);
            Console.WriteLine("Documento: " + joven.Documento);
            Console.WriteLine("DESEA ELIMINAR EL JOVEN ENCONTRADO?");
            Console.WriteLine("Oprima 1 Para ELIMINAR  -  Oprima 2 Para CANCELAR");
            string Seleccion = Console.ReadLine();
            if (Seleccion == "1"){
                _repoJoven.DeleteJoven(joven.Documento);
                Console.WriteLine("DATOS DEL JOVEN ELIMINADOS");
            }
            else if (Seleccion == "2"){
                Console.WriteLine("OPERACION CANCELADA");
            }
        }

        private static void ActualizarJoven(){
            Console.WriteLine("Ingrese El Numero De Documento del Joven a Editar: ");
            string? DocumentoJoven = Console.ReadLine();
            var jovenViejo = _repoJoven.GetJoven(DocumentoJoven);
            Console.WriteLine("Se van a actualizar los datos del Joven " + jovenViejo.Nombre + " " + jovenViejo.Apellidos);


            
            Console.WriteLine("Ingrese Su nuevo Nombre: ");
            string? NombreJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Sus nuevos Apellidos: ");
            string? ApellidosJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Su nuevo Numero De Telefono: ");
            string? TelefonoJoven = Console.ReadLine();
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
            Console.WriteLine("Ingrese El Nombre De Su nueva Ciudad: ");
            string? CiudadJoven = Console.ReadLine();
            

            var jovenNuevo = new Joven{
                Nombre = NombreJoven,
                Apellidos = ApellidosJoven,
                NumeroTelefono = TelefonoJoven,
                Documento = jovenViejo.Documento,
                Genero = generoEscojido,
                Latitud =  5.07F,
                Longitud = -75.687F,
                Ciudad = CiudadJoven,
                FechaNacimiento = jovenViejo.FechaNacimiento

            };
            _repoJoven.UpdateJoven(jovenNuevo);
            Console.WriteLine("Datos del Joven Actualizados!");
        }

    }
}