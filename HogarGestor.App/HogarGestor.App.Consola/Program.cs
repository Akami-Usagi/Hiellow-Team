
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

        }
        

    }
}