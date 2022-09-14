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

        private static IRepositorioMedico
            _repoMedico = new RepositorioMedico(new Persistencia.AppContext());

        private static IRepositorioJoven
            _repoJoven = new RepositorioJoven(new Persistencia.AppContext());


        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //AddFamiliar();
            //AddMedico();
            AddJoven();

            //GetJoven(6);
            //GetJoven(2);
            //Delete(12);
            //GetAllJoven();
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
            /*var familiar =
                new Familiar {
                    Nombre = "Daniela",
                    Apellido = "Velasco velez",
                    Telefono = "343567890",
                    Documento = "113456723",
                    TipoDocumentoId = 1,
                    GeneroId = 2,
                    Parentesco = "Hermana",
                    Correo = "daniela123@gmail.com"
                };*/
            _repoFamiliar.AddFamiliar (familiar);
        }

        private static void AddMedico()
        {
            var medico =
                new Medico {
                    Nombre = "Andrea",
                    Apellido = "Troches",
                    Telefono = "456780023",
                    Documento = "1234566778",
                    TipoDocumentoId = 1,
                    GeneroId = 2,
                    Rethus = "Especialista en Pediatria",
                    TarjetaProfesional = "12340008",
                    Especialidad = Especialidad.Pediatria
                };


                /*var medico =
                new Medico {
                    Nombre = "Felipe",
                    Apellido = "Rosero Alcala",
                    Telefono = "3363892345",
                    Documento = "1144095673",
                    TipoDocumentoId = 1,
                    GeneroId = 1,
                    Rethus = "Especialista en Nutricion",
                    TarjetaProfesional = "00945678",
                    Especialidad = Especialidad.Nutricion
                };*/

                _repoMedico.AddMedico(medico);
        }

        private static void AddJoven()
        {
            /*var joven =
                new Joven {
                    Nombre = "Dilan Matias",
                    Apellido = "Lopez Rojas",
                    Telefono = "323456891",
                    Documento = "123456789",
                    TipoDocumentoId = 2,
                    GeneroId = 1,
                    Latitud = 5.07F,
                    Longitud = -75.687F,
                    Ciudad = "Cali",
                    FamiliarId = 1,
                    FechaNacimiento = new DateTime(2014, 05, 07)
                };*/
            var joven =
                new Joven {
                    Nombre = "Jorge Luis",
                    Apellido = "Velasco Rojas",
                    Telefono = "323456891",
                    Documento = "456437860",
                    TipoDocumentoId = 2,
                    GeneroId = 1,
                    Latitud = 5.07F,
                    Longitud = -75.687F,
                    Ciudad = "Cali",
                    FamiliarId = 12,
                    FechaNacimiento = new DateTime(2014, 05, 07)
                };
            _repoJoven.AddJoven (joven);
        }

        public static void GetAllJoven()
        {
            var jovenes = _repoJoven.GetAllJovenes();
            foreach (var joven in jovenes)
            {
                Console.WriteLine(joven.Nombre + "  " + joven.Apellido);
            }
        }

        private static void GetJoven(int IdJoven)
        {
            var joven = _repoJoven.GetJoven(IdJoven);
            Console.WriteLine(joven.Nombre + " " + joven.Apellido);
        }

        private static void UpdateJoven(Joven joven)
        {
        }

        private static void Delete(int id)
        {
            
            _repoFamiliar.DeleteFamiliar(id);
            //_repoMedico.DeleteMedico(id);
            //_repoJoven.DeleteJoven(id);

        }
    }
}
