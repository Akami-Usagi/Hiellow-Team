﻿using System;
using System.Linq;
using HogarGestor.App.Dominio;
using HogarGestor.App.Persistencia;
using HogarGestor.App.Persistencia.AppRepositorio;

namespace HogarGestor.App.Consola
{
    class Program
    {

        // Repositorios
        private static IRepositorioJoven _repoJoven = new RepositorioJoven(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        private static IRepositorioFamiliar _repoFamiliar = new RepositorioFamiliar(new Persistencia.AppContext());

        // Programa Principal
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a HogarGestor.App");
            Console.WriteLine("");
            Console.WriteLine("Seleccione El Tipo de Persona que desea Consultar");
            Console.WriteLine("");
            Console.WriteLine("Ingrese 1-Joven   Ingrese 2-Medico   Ingrese 3-Familiar");
            string TipoPersona = Console.ReadLine();
            if (TipoPersona == "1")
            {
                Console.WriteLine("Gestion de Jovenes");
                Console.WriteLine("");
                Console.WriteLine("Ingrese 1 para agregar un joven.  - Ingrese 2 Para Buscar en la base de datos");
                Console.WriteLine("Ingrese 3 para eliminar un joven.  - Ingrese 4 Editar un Joven");
                Console.WriteLine("Ingrese 5 para lista completa de Jovenes registrados");
                string Option = Console.ReadLine();
                if (Option == "1")
                {
                    AddJoven();
                }
                else if (Option == "2")
                {
                    BuscarJoven();
                }
                else if (Option == "3")
                {
                    EliminarJoven();
                }
                else if (Option == "4")
                {
                    ActualizarJoven();
                }
                else if (Option == "5")
                {
                    ListaJovenes();
                }

            }

            if (TipoPersona == "2"){
                Console.WriteLine("Gestion de Medicos");
                Console.WriteLine("");
                Console.WriteLine("Ingrese 1 para agregar un Medico.  - Ingrese 2 Para Buscar en la base de datos");
                Console.WriteLine("Ingrese 3 para eliminar un Medico.  - Ingrese 4 Editar un Medico");
                Console.WriteLine("Ingrese 5 para lista completa de Medicos registrados");
                string Option = Console.ReadLine();
                if (Option == "1")
                {
                    AddMedico();
                }
                else if (Option == "2")
                {
                    BuscarMedico();
                }
                else if (Option == "3")
                {
                    EliminarMedico();
                }
                else if (Option == "4")
                {
                    ActualizarMedico();
                }
                else if (Option == "5")
                {
                    ListaMedicos();
                }

            }

        }

        // FUNCIONES DE JOVENES
        private static void AddJoven()
        {
            Console.WriteLine("Se Va Agregar Un Nuevo Joven Al Sistema: ");
            Console.WriteLine("Ingrese Su Nombre: ");
            string? NombreJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Sus Apellidos: ");
            string? ApellidosJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Su Numero De Telefono: ");
            string? TelefonoJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Su Numero De Documento: ");
            string? DocumentoJoven = Console.ReadLine();
            Console.WriteLine("Digite el Numero Segun Su Genero: 1-Masculino  2-Femenino  3-Intersexual");
            string? SelectGenero = Console.ReadLine();

            Generos? generoEscojido = null;
            if (SelectGenero == "1")
            {
                generoEscojido = Generos.Masculino;
            }
            else if (SelectGenero == "2")
            {
                generoEscojido = Generos.Femenino;
            }
            else if (SelectGenero == "3")
            {
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

            var joven = new Joven
            {
                Nombre = NombreJoven,
                Apellidos = ApellidosJoven,
                NumeroTelefono = TelefonoJoven,
                Documento = DocumentoJoven,
                Genero = generoEscojido,
                Latitud = 5.07F,
                Longitud = -75.687F,
                Ciudad = CiudadJoven,
                FechaNacimiento = new DateTime(Año, Mes, Dia)

            };
            _repoJoven.AddJoven(joven);
            Console.WriteLine("Datos Del Joven Agregados Satisfactoriamente!");
        }

        private static void BuscarJoven()
        {
            Console.WriteLine("Ingrese El Numero De Documento a Buscar: ");
            string? DocumentoJoven = Console.ReadLine();
            var joven = _repoJoven.GetJoven(DocumentoJoven);
            Console.WriteLine("");
            Console.WriteLine("Datos Del Joven Encontrados! ");
            Console.WriteLine("");
            Console.WriteLine("Nombre Completo: " + joven.Nombre + " " + joven.Apellidos);
            Console.WriteLine("Documento: " + joven.Documento);
            Console.WriteLine("Numero de Telefono: " + joven.NumeroTelefono);
        }

        private static void EliminarJoven()
        {
            Console.WriteLine("Ingrese El Numero De Documento del Joven a Eliminar: ");
            string? DocumentoJoven = Console.ReadLine();
            var joven = _repoJoven.GetJoven(DocumentoJoven);
            Console.WriteLine("");
            Console.WriteLine("Datos Del Joven Encontrados! ");
            Console.WriteLine("");
            Console.WriteLine("Nombre Completo: " + joven.Nombre + " " + joven.Apellidos);
            Console.WriteLine("Documento: " + joven.Documento);
            Console.WriteLine("");
            Console.WriteLine("DESEA ELIMINAR EL JOVEN ENCONTRADO?");
            Console.WriteLine("");
            Console.WriteLine("Oprima 1 Para ELIMINAR  -  Oprima 2 Para CANCELAR");
            string Seleccion = Console.ReadLine();
            if (Seleccion == "1")
            {
                _repoJoven.DeleteJoven(joven.Documento);
                Console.WriteLine("");
                Console.WriteLine("DATOS DEL JOVEN ELIMINADOS");
            }
            else if (Seleccion == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("OPERACION CANCELADA");
            }
        }

        private static void ActualizarJoven()
        {
            Console.WriteLine("Ingrese El Numero De Documento del Joven a Editar: ");
            string? DocumentoJoven = Console.ReadLine();
            var jovenViejo = _repoJoven.GetJoven(DocumentoJoven);
            Console.WriteLine("Se van a actualizar los datos del Joven " + jovenViejo.Nombre + " " + jovenViejo.Apellidos);
            Console.WriteLine("");

            Console.WriteLine("Ingrese Su nuevo Nombre: ");
            string? NombreJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Sus nuevos Apellidos: ");
            string? ApellidosJoven = Console.ReadLine();
            Console.WriteLine("Ingrese Su nuevo Numero De Telefono: ");
            string? TelefonoJoven = Console.ReadLine();
            Console.WriteLine("Digite el Numero Su Genero: 1-Masculino  2-Femenino  3-Intersexual");
            string? SelectGenero = Console.ReadLine();

            Generos? generoEscojido = null;
            if (SelectGenero == "1")
            {
                generoEscojido = Generos.Masculino;
            }
            else if (SelectGenero == "2")
            {
                generoEscojido = Generos.Femenino;
            }
            else if (SelectGenero == "3")
            {
                generoEscojido = Generos.Intersexual;
            }
            Console.WriteLine("Ingrese El Nombre De Su nueva Ciudad: ");
            string? CiudadJoven = Console.ReadLine();


            var jovenNuevo = new Joven
            {
                Nombre = NombreJoven,
                Apellidos = ApellidosJoven,
                NumeroTelefono = TelefonoJoven,
                Documento = jovenViejo.Documento,
                Genero = generoEscojido,
                Latitud = 5.07F,
                Longitud = -75.687F,
                Ciudad = CiudadJoven,
                FechaNacimiento = jovenViejo.FechaNacimiento

            };
            _repoJoven.UpdateJoven(jovenNuevo);
            Console.WriteLine("");
            Console.WriteLine("Datos del Joven Actualizados!");
        }

        public static void ListaJovenes()
        {
            List<Joven> Lista = _repoJoven.GetAllJovenes().ToList();
            Console.WriteLine("Lista De Jovenes en la Base de Datos: ");
            Console.WriteLine("");
            foreach (var joven in Lista)
            {
                Console.WriteLine("Nombre: " + joven.Nombre + " " + joven.Apellidos + " Documento: " + joven.Documento);
            }
        }


        // FUNCIONES DE MEDICOS

        private static void AddMedico()
        {
            Console.WriteLine("Se Va Agregar Un Nuevo Medico Al Sistema: ");
            Console.WriteLine("");
            Console.WriteLine("Ingrese Su Nombre: ");
            string? NombreMedico = Console.ReadLine();
            Console.WriteLine("Ingrese Sus Apellidos: ");
            string? ApellidosMedico = Console.ReadLine();
            Console.WriteLine("Ingrese Su Numero De Telefono: ");
            string? TelefonoMedico = Console.ReadLine();
            Console.WriteLine("Ingrese Su Numero De Documento: ");
            string? DocumentoMedico = Console.ReadLine();
            Console.WriteLine("Digite el Numero Segun Su Genero: 1-Masculino  2-Femenino  3-Intersexual");
            string? SelectGenero = Console.ReadLine();

            Generos? generoEscojido = null;
            if (SelectGenero == "1")
            {
                generoEscojido = Generos.Masculino;
            }
            else if (SelectGenero == "2")
            {
                generoEscojido = Generos.Femenino;
            }
            else if (SelectGenero == "3")
            {
                generoEscojido = Generos.Intersexual;
            }

            Console.WriteLine("Ingrese el Numero del Registro RETHUS: ");
            string RethusMedico = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de la Tarjeta Profesional: ");
            string TarjetaMedico = Console.ReadLine();

            Console.WriteLine("Digite el Numero Segun Su Especialidad: 1-Pediatria  2-Nutricion");
            string? SelectEspecialidad = Console.ReadLine();

            Especialidad? EspecialidadEscojida = null;
            if (SelectEspecialidad == "1")
            {
                EspecialidadEscojida = Especialidad.Pediatria;
            }
            else if (SelectEspecialidad == "2")
            {
                EspecialidadEscojida = Especialidad.Nutricion;
            }


            var medico = new Medico
            {
                Nombre = NombreMedico,
                Apellidos = ApellidosMedico,
                NumeroTelefono = TelefonoMedico,
                Documento = DocumentoMedico,
                Genero = generoEscojido,
                Rethus = RethusMedico,
                TarjetaProfesional = TarjetaMedico,
                EspecialidadMedica = EspecialidadEscojida


            };
            _repoMedico.AddMedico(medico);
            Console.WriteLine("");
            Console.WriteLine("Datos Del Medico Agregados Satisfactoriamente!");
        }

        private static void BuscarMedico()
        {
            Console.WriteLine("Ingrese El Numero De Documento a Buscar: ");
            string? DocumentoMedico = Console.ReadLine();
            var medico = _repoMedico.GetMedico(DocumentoMedico);
            Console.WriteLine("");
            Console.WriteLine("Datos Del Medico Encontrados! ");
            Console.WriteLine("");
            Console.WriteLine("Nombre Completo: " + medico.Nombre + " " + medico.Apellidos);
            Console.WriteLine("Documento: " + medico.Documento);
            Console.WriteLine("Numero de Telefono: " + medico.NumeroTelefono);
        }

        private static void EliminarMedico()
        {
            Console.WriteLine("Ingrese El Numero De Documento del Medico a Eliminar: ");
            string? DocumentoMedico = Console.ReadLine();
            var medico = _repoMedico.GetMedico(DocumentoMedico);
            Console.WriteLine("");
            Console.WriteLine("Datos Del Medico Encontrados! ");
            Console.WriteLine("");
            Console.WriteLine("Nombre Completo: " + medico.Nombre + " " + medico.Apellidos);
            Console.WriteLine("Documento: " + medico.Documento);
            Console.WriteLine("");
            Console.WriteLine("DESEA ELIMINAR EL MEDICO ENCONTRADO?");
            Console.WriteLine("");
            Console.WriteLine("Oprima 1 Para ELIMINAR  -  Oprima 2 Para CANCELAR");
            string Seleccion = Console.ReadLine();
            if (Seleccion == "1")
            {
                _repoMedico.DeleteMedico(medico.Documento);
                Console.WriteLine("");
                Console.WriteLine("DATOS DEL JOVEN ELIMINADOS");
            }
            else if (Seleccion == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("OPERACION CANCELADA");
            }
        }

        private static void ActualizarMedico()
        {
            Console.WriteLine("Ingrese El Numero De Documento del Medico a Editar: ");
            string? DocumentoMedico = Console.ReadLine();
            var MedicoViejo = _repoMedico.GetMedico(DocumentoMedico);
            Console.WriteLine("Se van a actualizar los datos del Medico " + MedicoViejo.Nombre + " " + MedicoViejo.Apellidos);



            Console.WriteLine("Ingrese Su Nuevo Nombre: ");
            string? NombreMedico = Console.ReadLine();
            Console.WriteLine("Ingrese Sus Nuevos Apellidos: ");
            string? ApellidosMedico = Console.ReadLine();
            Console.WriteLine("Ingrese Su Nuevo Numero De Telefono: ");
            string? TelefonoMedico = Console.ReadLine();
            Console.WriteLine("Digite el Numero Segun Su Genero: 1-Masculino  2-Femenino  3-Intersexual");
            string? SelectGenero = Console.ReadLine();

            Generos? generoEscojido = null;
            if (SelectGenero == "1")
            {
                generoEscojido = Generos.Masculino;
            }
            else if (SelectGenero == "2")
            {
                generoEscojido = Generos.Femenino;
            }
            else if (SelectGenero == "3")
            {
                generoEscojido = Generos.Intersexual;
            }

            Console.WriteLine("Ingrese el Nuevo Numero del Registro RETHUS: ");
            string RethusMedico = Console.ReadLine();
            Console.WriteLine("Ingrese el Nuevo Numero de la Tarjeta Profesional: ");
            string TarjetaMedico = Console.ReadLine();

            Console.WriteLine("Digite el Numero Segun Su Especialidad: 1-Pediatria  2-Nutricion");
            string? SelectEspecialidad = Console.ReadLine();

            Especialidad? EspecialidadEscojida = null;
            if (SelectEspecialidad == "1")
            {
                EspecialidadEscojida = Especialidad.Pediatria;
            }
            else if (SelectEspecialidad == "2")
            {
                EspecialidadEscojida = Especialidad.Nutricion;
            }


            var medicoNuevo = new Medico
            {
                Nombre = NombreMedico,
                Apellidos = ApellidosMedico,
                NumeroTelefono = TelefonoMedico,
                Documento = MedicoViejo.Documento,
                Genero = generoEscojido,
                Rethus = RethusMedico,
                TarjetaProfesional = TarjetaMedico,
                EspecialidadMedica = EspecialidadEscojida


            };
            _repoMedico.UpdateMedico(medicoNuevo);
            Console.WriteLine("Datos del Medico Actualizados!");
        }

        public static void ListaMedicos()
        {
            List<Medico> Lista = _repoMedico.GetAllMedicos().ToList();
            Console.WriteLine("Lista De Medicos en la Base de Datos: ");
            Console.WriteLine("");
            foreach (var medico in Lista)
            {
                Console.WriteLine("Nombre: " + medico.Nombre + " " + medico.Apellidos + " Documento: " + medico.Documento + " Tarjeta Profesional: " + medico.TarjetaProfesional);
            }
        }

    }
}